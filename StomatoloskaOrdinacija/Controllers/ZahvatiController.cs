﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StomatoloskaOrdinacija.DAL;
using StomatoloskaOrdinacija.Domain.DTOs;
using StomatoloskaOrdinacija.Domain.Repository;

namespace StomatoloskaOrdinacija.Controllers
{
    public class ZahvatiController : Controller
    {
        private OrdinacijaDb db = new OrdinacijaDb();
        ZahvatiRepository zr = new ZahvatiRepository();

        // GET: Zahvati
        public ActionResult Index()
        {
            var res = zr.GetPopisZahvata();
            return View(res);
        }

        // GET: Zahvati/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahvatDTO zahvatDTO = zr.GetZahvatById(id);
            if (zahvatDTO == null)
            {
                return HttpNotFound();
            }
            return View(zahvatDTO);
        }

        // GET: Zahvati/Create
        public ActionResult Create()
        {
            var zahvat = zr.GetEmptyZahvat();
            return View(zahvat);
        }

        // POST: Zahvati/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Sifra,Naziv,CijenaID,TrajanjeID,Cijena,Trajanje")] ZahvatDTO zahvatDTO)
        {
            if (ModelState.IsValid)
            {
                zr.CreateNewZahvat(zahvatDTO);

                return RedirectToAction("Index");
            }

            return View(zahvatDTO);
        }

        // GET: Zahvati/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahvatDTO zahvatDTO = zr.GetZahvatById(id);
            if (zahvatDTO == null)
            {
                return HttpNotFound();
            }
            return View(zahvatDTO);
        }

        // POST: Zahvati/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Sifra,Naziv,CijenaID,TrajanjeID,Cijena,Trajanje")] ZahvatDTO zahvatDTO)
        {
            if (ModelState.IsValid)
            {
                zr.EditZahvat(zahvatDTO);

                return RedirectToAction("Index");
            }
            return View(zahvatDTO);
        }

        // GET: Zahvati/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZahvatDTO zahvatDTO = zr.GetZahvatById(id);
            if (zahvatDTO == null)
            {
                return HttpNotFound();
            }
            return View(zahvatDTO);
        }

        // POST: Zahvati/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZahvatDTO zahvatDTO = zr.GetZahvatById(id);

            zr.DeleteZahvat(zahvatDTO);

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