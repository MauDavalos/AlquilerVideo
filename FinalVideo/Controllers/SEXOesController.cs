﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalVideo;

namespace FinalVideo.Controllers
{
    public class SEXOesController : Controller
    {
        private videoEntities db = new videoEntities();

        // GET: SEXOes
        public ActionResult Index()
        {
            return View(db.SEXO.ToList());
        }

        // GET: SEXOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEXO sEXO = db.SEXO.Find(id);
            if (sEXO == null)
            {
                return HttpNotFound();
            }
            return View(sEXO);
        }

        // GET: SEXOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SEXOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SEX_ID,SEX_NOMBRE")] SEXO sEXO)
        {
            if (ModelState.IsValid)
            {
                db.SEXO.Add(sEXO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sEXO);
        }

        // GET: SEXOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEXO sEXO = db.SEXO.Find(id);
            if (sEXO == null)
            {
                return HttpNotFound();
            }
            return View(sEXO);
        }

        // POST: SEXOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SEX_ID,SEX_NOMBRE")] SEXO sEXO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEXO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sEXO);
        }

        // GET: SEXOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEXO sEXO = db.SEXO.Find(id);
            if (sEXO == null)
            {
                return HttpNotFound();
            }
            return View(sEXO);
        }

        // POST: SEXOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SEXO sEXO = db.SEXO.Find(id);
            db.SEXO.Remove(sEXO);
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
