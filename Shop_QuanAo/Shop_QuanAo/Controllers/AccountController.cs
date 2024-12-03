using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Shop_QuanAo.Models;
using BCrypt.Net;

namespace Shop_QuanAo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private ShopQuanAoContext db = new ShopQuanAoContext();
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(NguoiDung model, string retypepassword)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.NguoiDung.FirstOrDefault(u => u.HoTen == model.HoTen);
                if (existingUser != null)
                {
                    ModelState.AddModelError("HoTen", "Họ Tên đã tồn tại.");
                    return View(model);
                }
                existingUser = db.NguoiDung.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại.");
                    return View(model);
                }
                if (model.MatKhau != retypepassword)
                {
                    ModelState.AddModelError("retypepassword", "Mật khẩu không khớp.");
                    return View(model);
                }
                model.MatKhau = BCrypt.Net.BCrypt.HashPassword(model.MatKhau);

                model.MaVaiTro = db.VaiTro.FirstOrDefault(v => v.TenVaiTro == "User")?.MaVaiTro ?? 2;
                model.NgayTao = DateTime.Now;

                db.NguoiDung.Add(model);
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(model.HoTen, false);

                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(NguoiDung user)
        {
            if (user != null )
            {
                NguoiDung myUser = db.NguoiDung.Where(u => u.HoTen == user.HoTen).FirstOrDefault();
                if(user.MatKhau!= null && BCrypt.Net.BCrypt.Verify(user.MatKhau, myUser.MatKhau))
                {

                    HttpCookie authCookie = new HttpCookie("auth", myUser.HoTen);
                    HttpCookie roleCookie = new HttpCookie("role", myUser.VaiTro.TenVaiTro);
                    Response.Cookies.Add(authCookie);
                    Response.Cookies.Add(roleCookie);
                    
                    return RedirectToAction("Index", "Home");
                }
                Session["UserId"] = user.MaNguoiDung;
            }

            ModelState.AddModelError("HoTen", "Thông tin đăng nhập không hợp lệ.");
            return View();
        }

        // Logout
        public ActionResult Logout()
        {
            if (Request.Cookies["auth"] != null)
            {
                HttpCookie authCookie = new HttpCookie("auth");
                authCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(authCookie);
            }

            if (Request.Cookies["role"] != null)
            {
                HttpCookie roleCookie = new HttpCookie("role");
                roleCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(roleCookie);
            }

            // Chuyển hướng về trang chủ sau khi đăng xuất
            return RedirectToAction("Index", "Home");
        }
    }
}
