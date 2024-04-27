﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using okul_yonetim.Models;

namespace okul_yonetim.Controllers
{
    public class YoneticisController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Yoneticis
        public ActionResult Index()
        {
            return View(db.Yonetici.ToList());
        }

        // GET: Yoneticis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yonetici.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // GET: Yoneticis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yoneticis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YoneticiId,YoneticiAd,YoneticiSoyad,YoneticiRol,YoneticiSifre")] Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                db.Yonetici.Add(yonetici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yonetici);
        }

        // GET: Yoneticis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yonetici.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // POST: Yoneticis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YoneticiId,YoneticiAd,YoneticiSoyad,YoneticiRol,YoneticiSifre")] Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yonetici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yonetici);
        }

        // GET: Yoneticis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yonetici yonetici = db.Yonetici.Find(id);
            if (yonetici == null)
            {
                return HttpNotFound();
            }
            return View(yonetici);
        }

        // POST: Yoneticis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yonetici yonetici = db.Yonetici.Find(id);
            db.Yonetici.Remove(yonetici);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
