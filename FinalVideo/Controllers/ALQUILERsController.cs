﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalVideo.Models;

namespace FinalVideo.Controllers
{
    public class ALQUILERsController : Controller
    {
        private videoEntities db = new videoEntities();

        
        static List<ALQUILER> ListaAlquiler = new List<ALQUILER>();
        static List<SOCIO> ListaSocio = new List<SOCIO>();

        

        // GET: ALQUILERs
        public ActionResult Index()
        {

            var aLQUILER = db.ALQUILER.Include(a => a.PELICULA).Include(a => a.SOCIO);
            return View(aLQUILER.ToList());
        }

        // GET: ALQUILERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALQUILER aLQUILER = db.ALQUILER.Find(id);
            if (aLQUILER == null)
            {
                return HttpNotFound();
            }
            return View(aLQUILER);
        }

        // GET: ALQUILERs/Create
        public ActionResult Create()
        {
            ViewBag.PEL_ID = new SelectList(db.PELICULA, "PEL_ID", "PEL_NOMBRE");
            ViewBag.SOC_ID = new SelectList(db.SOCIO, "SOC_ID", "SOC_NOMBRE");
            return View();
        }

        // POST: ALQUILERs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ALQ_ID,SOC_ID,PEL_ID,ALQ_FECHA_DESDE,ALQ_FECHA_HASTA,ALQ_VALOR,ALQ_FECHA_ENTREGA")] ALQUILER aLQUILER)
        {
            if (ModelState.IsValid)
            {
                db.ALQUILER.Add(aLQUILER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PEL_ID = new SelectList(db.PELICULA, "PEL_ID", "PEL_NOMBRE", aLQUILER.PEL_ID);
            ViewBag.SOC_ID = new SelectList(db.SOCIO, "SOC_ID", "SOC_CEDULA", aLQUILER.SOC_ID);
            return View(aLQUILER);
        }

        // GET: ALQUILERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALQUILER aLQUILER = db.ALQUILER.Find(id);
            if (aLQUILER == null)
            {
                return HttpNotFound();
            }
            ViewBag.PEL_ID = new SelectList(db.PELICULA, "PEL_ID", "PEL_NOMBRE", aLQUILER.PEL_ID);
            ViewBag.SOC_ID = new SelectList(db.SOCIO, "SOC_ID", "SOC_CEDULA", aLQUILER.SOC_ID);
            return View(aLQUILER);
        }

        // POST: ALQUILERs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ALQ_ID,SOC_ID,PEL_ID,ALQ_FECHA_DESDE,ALQ_FECHA_HASTA,ALQ_VALOR,ALQ_FECHA_ENTREGA")] ALQUILER aLQUILER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLQUILER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PEL_ID = new SelectList(db.PELICULA, "PEL_ID", "PEL_NOMBRE", aLQUILER.PEL_ID);
            ViewBag.SOC_ID = new SelectList(db.SOCIO, "SOC_ID", "SOC_CEDULA", aLQUILER.SOC_ID);
            return View(aLQUILER);
        }

        // GET: ALQUILERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALQUILER aLQUILER = db.ALQUILER.Find(id);
            if (aLQUILER == null)
            {
                return HttpNotFound();
            }
            return View(aLQUILER);
        }

        // POST: ALQUILERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALQUILER aLQUILER = db.ALQUILER.Find(id);
            db.ALQUILER.Remove(aLQUILER);
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
