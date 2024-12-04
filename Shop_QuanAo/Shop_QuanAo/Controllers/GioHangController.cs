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
        //[HttpPost]
        //public ActionResult Checkout(List<int> selectedItems)
        //{
        //    string userName = Request.Cookies["auth"]?.Value;
        //    var user = db.NguoiDung.FirstOrDefault(u => u.HoTen == userName);

        //    if (user == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }

        //    if (selectedItems != null && selectedItems.Any())
        //    {
        //        foreach (var itemId in selectedItems)
        //        {
        //            var cartItem = db.GioHang.Find(itemId);
        //            if (cartItem != null && cartItem.MaNguoiDung == user.MaNguoiDung)
        //            {
        //                db.GioHang.Remove(cartItem); // Xóa khỏi giỏ hàng
        //                                             // Thêm logic lưu thông tin hóa đơn nếu cần
        //            }
        //        }
        //        db.SaveChanges();
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult Checkout(List<int> selectedItems)
        {
            string userName = Request.Cookies["auth"]?.Value;
            var user = db.NguoiDung.FirstOrDefault(u => u.HoTen == userName);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Kiểm tra xem người dùng có chọn sản phẩm không
            if (selectedItems != null && selectedItems.Any())
            {
                // Tạo một đơn hàng mới
                var newOrder = new DonHang
                {
                    MaNguoiDung = user.MaNguoiDung,
                    NgayTao = DateTime.Now,
                    TrangThaiDonHang = "Chờ duyệt", // Trang thái đơn hàng ban đầu
                    TongTien = 0, // Đặt tổng tiền ban đầu là 0, sẽ tính sau
                    MaCuaHang = 1 // Cửa hàng mặc định là 1 (có thể thay đổi nếu cần)
                };
                db.DonHang.Add(newOrder);
                db.SaveChanges(); // Lưu để có MaDonHang

                decimal totalAmount = 0;

                // Duyệt qua các sản phẩm đã chọn
                foreach (var itemId in selectedItems)
                {
                    var cartItem = db.GioHang.Include(g => g.SanPham)
                                             .FirstOrDefault(g => g.MaGioHang == itemId && g.MaNguoiDung == user.MaNguoiDung);

                    if (cartItem != null)
                    {
                        // Lưu chi tiết đơn hàng vào ChiTietDonHang
                        var orderDetail = new ChiTietDonHang
                        {
                            MaDonHang = newOrder.MaDonHang,
                            MaSanPham = cartItem.MaSanPham,
                            SoLuong = cartItem.SoLuong,
                            DonGia = cartItem.SanPham.Gia
                        };
                        db.ChiTietDonHang.Add(orderDetail);

                        // Cập nhật tổng tiền
                        totalAmount += cartItem.SoLuong * cartItem.SanPham.Gia;

                        // Xóa sản phẩm khỏi giỏ hàng sau khi thanh toán
                        db.GioHang.Remove(cartItem);
                    }
                }

                // Cập nhật tổng tiền vào đơn hàng
                newOrder.TongTien = totalAmount;
                db.SaveChanges(); // Lưu thay đổi

                // Chuyển hướng đến trang xác nhận đơn hàng
                return RedirectToAction("OrderConfirmation", new { orderId = newOrder.MaDonHang });
            }

            return RedirectToAction("Index");
        }
        public ActionResult OrderConfirmation(int orderId)
        {
            // Lấy đơn hàng theo mã đơn hàng
            var order = db.DonHang
                          .Include(o => o.ChiTietDonHang.Select(c => c.SanPham))  
                          .FirstOrDefault(o => o.MaDonHang == orderId);

            
            if (order == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(order); 
        }


        public ActionResult OrderHistory()
        {
            string userName = Request.Cookies["auth"]?.Value;
            var user = db.NguoiDung.FirstOrDefault(u => u.HoTen == userName);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = user.MaNguoiDung;

            // Lấy tất cả các đơn hàng của người dùng
            var orders = db.DonHang
                           .Where(d => d.MaNguoiDung == userId)
                           .Include(d => d.ChiTietDonHang.Select(c => c.SanPham))
                           .ToList();

            return View(orders); // Trả về danh sách đơn hàng
        }
        public ActionResult OrderDetails(int orderId)
        {
            var order = db.DonHang
                          .Include(o => o.ChiTietDonHang.Select(c => c.SanPham))
                          .FirstOrDefault(o => o.MaDonHang == orderId);

            if (order == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(order); // Trả về thông tin chi tiết đơn hàng
        }

    }
}