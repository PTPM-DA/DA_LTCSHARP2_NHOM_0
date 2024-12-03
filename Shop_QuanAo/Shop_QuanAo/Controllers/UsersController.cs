using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_QuanAo.Models;
using Shop_QuanAo.Filters;
using System.Data.Entity;

namespace Shop_QuanAo.Controllers
{
    public class UsersController : Controller
    {
        private ShopQuanAoContext db = new ShopQuanAoContext();
        // GET: Users
        public ActionResult Index()
        {
            var authCookie = Request.Cookies["auth"];
            if (authCookie == null || string.IsNullOrEmpty(authCookie.Value))
            {
                return RedirectToAction("Login", "Account");
            }

            var userName = authCookie.Value;
            var user = db.NguoiDung.FirstOrDefault(u => u.HoTen == userName);

            if (user == null)
            {
                return HttpNotFound("Người dùng không tồn tại.");
            }

            return View(user);
        }
        [AuthFilterAtribute]
        public ActionResult EditUsers(int id)
        {
            var user = db.NguoiDung.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            // Truyền thông tin của người dùng vào view
            return View(user);
        }

        // POST: Cập nhật thông tin người dùng
        [HttpPost]
        public ActionResult EditUsers(NguoiDung model, string retypepassword)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.NguoiDung.FirstOrDefault(u => u.HoTen == model.HoTen && u.MaNguoiDung != model.MaNguoiDung);
                if (existingUser != null)
                {
                    ModelState.AddModelError("HoTen", "Họ Tên đã tồn tại.");
                    return View(model);
                }

                existingUser = db.NguoiDung.FirstOrDefault(u => u.Email == model.Email && u.MaNguoiDung != model.MaNguoiDung);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại.");
                    return View(model);
                }

                // Kiểm tra mật khẩu
                if (!string.IsNullOrEmpty(model.MatKhau))
                {
                    if (model.MatKhau != retypepassword)
                    {
                        ModelState.AddModelError("retypepassword", "Mật khẩu không khớp.");
                        return View(model);
                    }
                    model.MatKhau = BCrypt.Net.BCrypt.HashPassword(model.MatKhau);
                }

                // Cập nhật thông tin người dùng trong cơ sở dữ liệu
                var userInDb = db.NguoiDung.Find(model.MaNguoiDung);
                if (userInDb == null)
                {
                    return HttpNotFound();
                }

                // Giữ nguyên mã vai trò và ngày tạo của người dùng
                userInDb.HoTen = model.HoTen;
                userInDb.Email = model.Email;
                userInDb.MatKhau = model.MatKhau ?? userInDb.MatKhau;
                userInDb.SoDienThoai = model.SoDienThoai;

                // Giữ nguyên mã vai trò và ngày tạo
                if (model.MaVaiTro != 0)
                {
                    userInDb.MaVaiTro = model.MaVaiTro;
                }
                if (model.NgayTao != null)
                {
                    userInDb.NgayTao = model.NgayTao;
                }

                db.SaveChanges();

                var oldCookie = Request.Cookies["auth"];
                if (oldCookie != null)
                {
                    oldCookie.Expires = DateTime.Now.AddDays(-1);  // Đặt thời gian hết hạn về quá khứ để xóa cookie
                    Response.Cookies.Add(oldCookie);
                }

                // Tạo cookie mới với giá trị thông tin người dùng đã cập nhật
                var newCookie = new HttpCookie("auth", model.HoTen)
                {
                    Expires = DateTime.Now.AddHours(1)  // Đặt thời gian hết hạn cookie
                };
                Response.Cookies.Add(newCookie);
                return RedirectToAction("Index", "Users");
            }

            return View(model);
        }
    }
}