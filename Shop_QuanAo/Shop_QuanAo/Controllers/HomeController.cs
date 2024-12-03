using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop_QuanAo.Models;

namespace Shop_QuanAo.Controllers
{
    public class HomeController : Controller
    {
        private ShopQuanAoContext db = new ShopQuanAoContext();
        
        public ActionResult Index(string search, string brandName = null)
        {
            List<SanPham> pro = db.SanPham.ToList();

            if (!string.IsNullOrEmpty(search))
            {
                pro = pro.Where(p => p.TenSanPham.Contains(search)).ToList();
            }

            var brands = db.DanhMucSanPham.ToList();

            ViewBag.Brands = brands;

            if (!string.IsNullOrEmpty(brandName))
            {

                pro = pro.Where(p => p.DanhMucSanPham.TenDanhMuc == brandName).ToList();
            }

            return View(pro);
        }
        public ActionResult ProductDetail(int id = 1)
        {
            var sanPham = db.SanPham.FirstOrDefault(sp => sp.MaSanPham == id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }

            var relatedProducts = db.SanPham
                                    .Where(sp => sp.MaDanhMuc == sanPham.MaDanhMuc && sp.MaSanPham != id)
                                    .Take(4)
                                    .ToList();

            ViewBag.RelatedProducts = relatedProducts;
            return View(sanPham);
        }

        public ActionResult Error404()
        {
            return View();
        }

    }
}