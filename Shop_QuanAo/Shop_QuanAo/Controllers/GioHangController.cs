using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_QuanAo.Filters;
using Shop_QuanAo.Models;
namespace Shop_QuanAo.Controllers
{
    public class GioHangController : Controller
    {
        private ShopQuanAoContext db = new ShopQuanAoContext();
        // GET: GioHang
        [AuthFilterAtribute]
        
        public ActionResult Index()
        {
            string userName = Request.Cookies["auth"]?.Value;
            var user = db.NguoiDung.FirstOrDefault(u => u.HoTen == userName);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = user.MaNguoiDung;

            var cartItems = db.GioHang
                              .Where(g => g.MaNguoiDung == userId)
                              .Include(g => g.SanPham)
                              .ToList();

            return View(cartItems);
        }
        public ActionResult AddToCart(int productId, int quantity = 1)
        {
            string userName = Request.Cookies["auth"]?.Value;
            var user = db.NguoiDung.FirstOrDefault(u => u.HoTen == userName);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = user.MaNguoiDung;

            var existingItem = db.GioHang.FirstOrDefault(g => g.MaNguoiDung == userId && g.MaSanPham == productId);

            if (existingItem != null)
            {
                existingItem.SoLuong += quantity;
            }
            else
            {
                var newCartItem = new GioHang
                {
                    MaNguoiDung = userId,
                    MaSanPham = productId,
                    SoLuong = quantity
                };
                db.GioHang.Add(newCartItem);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int cartItemId)
        {
            var cartItem = db.GioHang.Find(cartItemId);
            if (cartItem != null)
            {
                db.GioHang.Remove(cartItem);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateCart(int cartItemId, int quantity)
        {
            var cartItem = db.GioHang.Find(cartItemId);
            if (cartItem != null && quantity >= 1)
            {
                cartItem.SoLuong = quantity;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Checkout(List<int> selectedItems)
        {
            string userName = Request.Cookies["auth"]?.Value;
            var user = db.NguoiDung.FirstOrDefault(u => u.HoTen == userName);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (selectedItems != null && selectedItems.Any())
            {
                foreach (var itemId in selectedItems)
                {
                    var cartItem = db.GioHang.Find(itemId);
                    if (cartItem != null && cartItem.MaNguoiDung == user.MaNguoiDung)
                    {
                        db.GioHang.Remove(cartItem); // Xóa khỏi giỏ hàng
                                                     // Thêm logic lưu thông tin hóa đơn nếu cần
                    }
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}