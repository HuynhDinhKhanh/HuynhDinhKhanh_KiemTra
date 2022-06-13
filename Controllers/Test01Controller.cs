using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_HuynhDinhKhanh.Models;

namespace KiemTra_HuynhDinhKhanh.Controllers
{
    public class Test01Controller : Controller
    {
        Test01DataContext data = new Test01DataContext();
        // GET: Test01
        public ActionResult Index()
        {
            var all = from tt in data.SinhViens select tt;
            return View(all);
        }

        public ActionResult Detail(char id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }
        //-------------Create-------------------
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien tl)
        {
            var ten = collection["tenloai"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.MaSV = ten;
                data.SinhViens.InsertOnSubmit(tl);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        //-------------Edit-------------------
        public ActionResult Edit(char id)
        {
            var E_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(E_sinhvien);
        }
        [HttpPost]
        public ActionResult Edit(char id, FormCollection collection)
        {
            var sinhvien = data.SinhViens.First(m => m.MaSV == id);
            var E_sinhvien = collection["tenloai"];
            sinhvien.MaSV = id;
            if (string.IsNullOrEmpty(E_sinhvien))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sinhvien.MaSV = E_sinhvien;
                UpdateModel(sinhvien);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(char id)
        {
            var D_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(D_sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(char id, FormCollection collection)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sinhvien);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}