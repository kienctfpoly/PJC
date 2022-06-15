﻿using System.Collections.Generic;
using ASS_QLTV_API.Models;
using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PJC.Models;
using Sach = PJC.Models.Sach;

namespace PJC.Areas.PageReview
{
    [Area("PageReview")]
    public class ProductController : Controller
    {
        private APIServices _services;

        public ProductController()
        {
            _services = new APIServices();
        }

        private StoreContext context;
        void setDBContext()
        {
            if (context == null)
                context = HttpContext.RequestServices.GetService(typeof(StoreContext)) as StoreContext;
        }
        [HttpGet]
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
        public IActionResult Detail(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            Sach s = context.GetSachByMa(id);
            ViewData.Model = s;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string searchString)
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            return View(context.GetSanPhamSearch(searchString));
        }
    }
}
