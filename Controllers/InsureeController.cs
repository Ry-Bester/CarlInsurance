using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using CarlInsurance.Models;
using Microsoft.Ajax.Utilities;

namespace CarlInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        public object ApplicationDBContext { get; private set; }

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {


            if (ModelState.IsValid)
            {
                var Age = DateTime.Now.Year - insuree.DateOfBirth.Year;

                int basic = 50;
                if (Age <= 18)
                {
                    basic += 100;

                }
                else if (Age > 19 && Age < 25)
                {
                    basic += 50;

                }

                else if (Age > 25)
                {
                    basic += 25;

                }

                if (insuree.CarYear < 2000)
                {
                    basic += 25;
                }
                else if (insuree.CarYear > 2015)
                {
                    basic += 25;
                }

                if (insuree.CarMake.ToLower() == "porsche")
                {
                    basic += 25;
                }
                else if (insuree.CarMake.ToLower() == "porsche" && insuree.CarModel.ToLower() == "911 carrera")
                {
                    basic += 25;
                }

                if (insuree.SpeedingTickets > 0)
                {
                    basic += insuree.SpeedingTickets * 10;
                }
                if (insuree.DUI == true)
                {
                    basic += basic / 4;
                }
                if (insuree.CoverageType == true)
                {
                    basic += basic / 2;
                }
                 insuree.Quote = basic;
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }
            


               
            

            
        

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {

                var Age = DateTime.Now.Year - insuree.DateOfBirth.Year;

                int basic = 50;
                if (Age <= 18)
                {
                    basic += 100;

                }
                else if (Age > 19 && Age < 25)
                {
                    basic += 50;

                }

                else if (Age > 25)
                {
                    basic += 25;

                }

                if (insuree.CarYear < 2000)
                {

                }
                else if (insuree.CarYear > 2015)
                {
                    basic += 25;
                }

                if (insuree.CarMake.ToLower() == "porsche")
                {
                    basic += 25;
                }
                else if (insuree.CarMake.ToLower() == "porsche" && insuree.CarModel.ToLower() == "911 carrera")
                {
                    basic += 25;
                }

                if (insuree.SpeedingTickets > 0)
                {
                    basic += insuree.SpeedingTickets * 10;
                }
                if (insuree.DUI == true)
                {
                    insuree.Quote += insuree.Quote / 4;
                }
                if (insuree.CoverageType == true)
                {
                    insuree.Quote += insuree.Quote / 2;
                }

                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
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

        public ActionResult Admin()
        {
            
            return View(db.Insurees);
        }


    }
}

           

    


