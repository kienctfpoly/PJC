﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using PJC.Models;

namespace PJC.Areas.User.Controllers
{
    //[Authorize]
    [Area("User")]
    public class PhieuMuonController : Controller
    {

        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            return View(context.GetPhieuMuon());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.sessionv= HttpContext.Session.GetString("user");
            return View();
        }
        [HttpPost]
        public IActionResult Create(PhieuMuon pm)
        {
            int count;
            HttpContext.Session.SetString("mapm", pm.MaPM);
           

            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.CreatePhieuMuon(pm);
            if (count > 0)
            {
                TempData["result"] = "Thêm mới phiếu mượn thành công";
            }
            else
            {
                TempData["result"] = "Thêm mới phiếu mượn không thành công";
            }
            return Redirect("~/User/PhieuTra/Create");
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            PhieuMuon pm = context.GetPhieuMuonByMaPM(id);
            ViewData.Model = pm;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(PhieuMuon pm)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.UpdatePhieuMuon(pm);
            if (count > 0)
            {
                TempData["result"] = "Cập nhật thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
            else
            {
                TempData["result"] = "Cập nhật không thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
        }
        
        [HttpPost]
        public IActionResult EditSoLuong(string id)
        {
            string a= HttpContext.Session.GetString("mapm");
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.UpdateSoLuongSach(a);
            if (count > 0)
            {
                TempData["result"] = "Cập nhật số lượng sách mượn thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
            else
            {
                TempData["result"] = "Cập nhật số lượng sách mượn không thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
        }
        public IActionResult Delete(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            PhieuMuon pm= context.GetPhieuMuonByMaPM(id);
            ViewData.Model = pm;
            return View();
        }
        [HttpPost]
        public IActionResult Delete(PhieuMuon pm)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.DeletePhieuMuon(pm);
            if (count > 0)
            {
                TempData["result"] = "Xóa phiếu mượn  thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
            else
            {
                TempData["result"] = "Xóa phiếu mượn không thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            PhieuMuon pm = context.GetPhieuMuonByMaPM(id);
            ViewData.Model = pm;
            return View();
        }
    }
}
