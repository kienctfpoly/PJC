using System.Collections.Generic;
using ASS_QLTV_API.Models;
using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PJC.Models;
using Sach = PJC.Models.Sach;

namespace PJC.Controllers
{
    public class ProductController : Controller
    {
        private StoreContext context;
        private APIServices _services;
        void setDBContext()
        {
            if (context == null)
                context = HttpContext.RequestServices.GetService(typeof(StoreContext)) as StoreContext;
        }

        public ProductController()
        {
            _services = new APIServices();
        }

        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //return View(context.GetSanPham());
            string data = _services.GetDataFromAPI("https://localhost:44301/", "api/Saches");
            List<ASS_QLTV_API.Models.Sach> productList = JsonConvert.DeserializeObject<List<ASS_QLTV_API.Models.Sach>>(data);
            return View(productList);
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
            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            else
            {
                TempData["result"] = "Cập nhật không thành công";
                return RedirectToAction("Index");
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
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["result"] = "Xóa sách không thành công";
                return RedirectToAction(nameof(Index));
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
