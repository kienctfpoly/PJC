using System.Collections.Generic;
using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PJC.Models;

namespace PJC.Areas.User
{
    [Area("User")]
    public class ProductController : Controller
    {
        private StoreContext context;
        private APIServices _services;

        public ProductController()
        {
            _services = new APIServices();
        }

        void setDBContext()
        {
            if (context == null)
                context = HttpContext.RequestServices.GetService(typeof(StoreContext)) as StoreContext;
        }
        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //return View(context.GetSanPham());
            var data = _services.GetDataFromAPI("https://localhost:44301/", "api/Saches");
            List<ASS_QLTV_API.Models.Sach> sachList =
                JsonConvert.DeserializeObject<List<ASS_QLTV_API.Models.Sach>>(data);
            return View(sachList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sach sach)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.CreateSach(sach);
            if (count > 0)
            {
                TempData["result"] = "Thêm mới sách thành công";
            }
            else
            {
                TempData["result"] = "Thêm mới sách không thành công";
            }
            return Redirect("~/User/Product/Index");
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            Sach s = context.GetSachByMa(id);
            ViewData.Model = s;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Sach s)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.UpdateProduct(s);
            if (count > 0)
            {
                TempData["result"] = "Cập nhật thành công";
                return Redirect("~/User/Product/Index");
            }
            else
            {
                TempData["result"] = "Cập nhật không thành công";
                return Redirect("~/User/Product/Index");
            }
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            Sach s = context.GetSachByMa(id);
            ViewData.Model = s;
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Sach s)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.DeleteSach(s);
            if (count > 0)
            {
                TempData["result"] = "Xóa sách  thành công";
                return Redirect("~/User/Product/Index");
            }
            else
            {
                TempData["result"] = "Xóa sách không thành công";
                return Redirect("~/User/Product/Index");
            }
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            Sach s = context.GetSachByMa(id);
            ViewData.Model = s;
            return View();
        }
    }
}
