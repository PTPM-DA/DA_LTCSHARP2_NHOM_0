using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_QuanAo.Models;

namespace Shop_QuanAo.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham

        private ShopQuanAoContext db = new ShopQuanAoContext();
        public ActionResult Index(string search, string sortOrder, int? danhMucId, int page = 1, int pageSize =6 )
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentDanhMuc = danhMucId;
            ViewBag.DanhMucs = db.DanhMucSanPham.ToList();
            var sanPhams = db.SanPham.AsQueryable();
            //tìm kiếm theo sản phâm
            if (!string.IsNullOrEmpty(search))
            {
                sanPhams = sanPhams.Where(s => s.TenSanPham.Contains(search));
            }
            //Lọc theo danh mục 
            if (danhMucId.HasValue)
            {
                sanPhams = sanPhams.Where(s => s.MaDanhMuc == danhMucId.Value);
            }
            //sắp xếp
            switch (sortOrder)
            {
                case "name_asc":
                    sanPhams = sanPhams.OrderBy(e => e.TenSanPham);
                    break;
                case "gia_desc":
                    sanPhams = sanPhams.OrderByDescending(e => e.Gia);
                    break;
                case "gia_asc":
                    sanPhams = sanPhams.OrderBy(e => e.Gia);
                    break;
                case "name_desc":
                    sanPhams = sanPhams.OrderByDescending(e => e.TenSanPham);
                    break;
                default:
                    sanPhams = sanPhams.OrderBy(e => e.MaSanPham);
                    break;
            }
            // phân trang
            int totalSamPham = sanPhams.Count();

            var pagedSanPham = sanPhams.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            int totalPages = (int)Math.Ceiling((double)totalSamPham / pageSize);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            return View(pagedSanPham);
        }

        public ActionResult Create()
        {
            List<DanhMucSanPham> dep = db.DanhMucSanPham.ToList();
            ViewBag.danhmuc = dep;
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham product, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                // Xử lý upload
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    if (imageFile.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Image", "Kích thước file không được lớn hơn 2MB.");
                        return View();
                    }

                    var allowedExtensions = new[] { ".jpg", ".png" };
                    var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("Image", "Chỉ chấp nhận file ảnh PNG hoặc JPG");
                        return View();
                    }

                    product.HinhAnh = "";
                    db.SanPham.Add(product);
                    db.SaveChanges();

                    db = new ShopQuanAoContext();
                    SanPham pro = db.SanPham.ToList().Last();

                    var fileName = pro.MaSanPham.ToString() + fileExtension;
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    imageFile.SaveAs(path);

                    pro.HinhAnh = fileName;
                    db.SaveChanges();

                    return RedirectToAction("QuanLySanPham", "Admin");
                }
                else
                {
                    product.HinhAnh = "";
                    db.SanPham.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("QuanLySanPham", "Admin");
                }
            }
            else
            {
                return View();
            }
        }
    }
}