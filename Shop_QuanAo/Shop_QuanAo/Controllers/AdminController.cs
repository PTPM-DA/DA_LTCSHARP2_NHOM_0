using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_QuanAo.Models;
using System.Data.Entity;
using System.IO;
using Shop_QuanAo.Filters;
using System.Data.Entity.Infrastructure;

namespace Shop_QuanAo.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        private ShopQuanAoContext db = new ShopQuanAoContext();
        [AdminFilterAtribute]
        public ActionResult QuanLyNguoiDung()
        {
            var users = db.NguoiDung.Include(n => n.VaiTro).ToList();
            return View(users);
        }
        // Quản lý sản phẩm
        [AdminFilterAtribute]
        public ActionResult QuanLySanPham()
        {
            var products = db.SanPham.ToList();
            return View(products);
        }

        // Quản lý đơn hàng
        [AdminFilterAtribute]
        public ActionResult QuanLyDonHang()
        {
            var orders = db.DonHang.Include(d => d.NguoiDung).Include(d => d.CuaHang).ToList();
            return View(orders);
        }

        // Thêm người dùng
        public ActionResult CreateUser()
        {
            ViewBag.Roles = db.VaiTro.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(NguoiDung user)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra trùng tên
                var existingUser = db.NguoiDung.FirstOrDefault(u => u.HoTen == user.HoTen);
                if (existingUser != null)
                {
                    ModelState.AddModelError("HoTen", "Họ Tên đã tồn tại.");
                    return View(user);
                }

                // Kiểm tra trùng email
                existingUser = db.NguoiDung.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại.");
                    return View(user);
                }

                // Hash mật khẩu
                user.MatKhau = BCrypt.Net.BCrypt.HashPassword(user.MatKhau);

                // Gán ngày tạo và thêm người dùng
                user.NgayTao = DateTime.Now;
                user.MaVaiTro = user.MaVaiTro; // Đảm bảo MaVaiTro hợp lệ
                try
                {
                    db.NguoiDung.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("QuanLyNguoiDung");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Lỗi khi lưu vào cơ sở dữ liệu: " + ex.Message);
                }
            }

            // Load lại Roles nếu có lỗi
            ViewBag.Roles = db.VaiTro.ToList();
            return View(user);
        }

        // Xóa người dùng

        public ActionResult DeleteUser(int id)
        {
            var user = db.NguoiDung.Find(id);
            if (user != null)
            {
                db.NguoiDung.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("QuanLyNguoiDung");
        }

        // Xóa sản phẩm
        public ActionResult DeleteProduct(int id)
        {
            var product = db.SanPham.Find(id);
            if (product != null)
            {
                db.SanPham.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("QuanLySanPham");
        }

        // Sửa người dùng
        public ActionResult EditUser(int id)
        {
            var user = db.NguoiDung.Find(id);
            if (user == null)
                return HttpNotFound();

            ViewBag.Roles = db.VaiTro
                .Select(v => new { v.MaVaiTro, v.TenVaiTro }) 
                .ToList();

            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(NguoiDung user)
        {
            if (ModelState.IsValid)
            {
                var currentUser = db.NguoiDung.Find(user.MaNguoiDung);
                if (currentUser == null)
                {
                    return HttpNotFound();
                }

                // Kiểm tra trùng tên (loại trừ người dùng hiện tại)
                var duplicateName = db.NguoiDung.FirstOrDefault(u => u.HoTen == user.HoTen && u.MaNguoiDung != user.MaNguoiDung);
                if (duplicateName != null)
                {
                    ModelState.AddModelError("HoTen", "Họ tên đã tồn tại.");
                }

                // Kiểm tra trùng email (loại trừ người dùng hiện tại)
                var duplicateEmail = db.NguoiDung
                    .FirstOrDefault(u => u.Email == user.Email && u.MaNguoiDung != user.MaNguoiDung);
                if (duplicateEmail != null)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại.");
                }

                // Nếu không có lỗi, tiếp tục xử lý cập nhật
                if (ModelState.IsValid)
                {
                    currentUser.HoTen = user.HoTen;
                    currentUser.Email = user.Email;
                    currentUser.SoDienThoai = user.SoDienThoai;
                    currentUser.MaVaiTro = user.MaVaiTro;

                    // Chỉ mã hóa mật khẩu nếu nó được thay đổi
                    if (!string.IsNullOrEmpty(user.MatKhau) && !BCrypt.Net.BCrypt.Verify(user.MatKhau, currentUser.MatKhau))
                    {
                        currentUser.MatKhau = BCrypt.Net.BCrypt.HashPassword(user.MatKhau);
                    }

                    try
                    {
                        db.Entry(currentUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("QuanLyNguoiDung");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Lỗi khi cập nhật dữ liệu: " + ex.Message);
                    }
                }
            }

            // Load lại Roles nếu có lỗi
            ViewBag.Roles = db.VaiTro.ToList();
            return View(user);
        }

        // Sửa sản phẩm
        public ActionResult EditProduct(int id)
        {
            var product = db.SanPham.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.danhmuc = db.DanhMucSanPham.ToList(); 
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(SanPham product, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = db.SanPham.Find(product.MaSanPham);
                if (existingProduct == null)
                {
                    return HttpNotFound();
                }

                // Cập nhật các thuộc tính
                existingProduct.TenSanPham = product.TenSanPham;
                existingProduct.MoTa = product.MoTa;
                existingProduct.Gia = product.Gia;
                existingProduct.MaDanhMuc = product.MaDanhMuc;
                existingProduct.NgayTao = product.NgayTao;

                // Xử lý upload ảnh
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    if (imageFile.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Image", "Kích thước file không được lớn hơn 2MB.");
                        ViewBag.danhmuc = db.DanhMucSanPham.ToList();
                        return View(product);
                    }

                    var allowedExtensions = new[] { ".jpg", ".png" };
                    var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("Image", "Chỉ chấp nhận file ảnh PNG hoặc JPG");
                        ViewBag.danhmuc = db.DanhMucSanPham.ToList();
                        return View(product);
                    }

                    // Lưu ảnh mới
                    var fileName = product.MaSanPham + fileExtension;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    imageFile.SaveAs(path);

                    // Gán lại đường dẫn ảnh
                    existingProduct.HinhAnh = fileName;
                }

                db.SaveChanges();
                return RedirectToAction("QuanLySanPham", "Admin");
            }

            ViewBag.danhmuc = db.DanhMucSanPham.ToList();
            return View(product);
        }
    }
}