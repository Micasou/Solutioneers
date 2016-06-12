using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Solutioneers.DAL;
using Solutioneers.Models;

namespace Solutioneers.Controllers
{
    public class HoursOfOperationsController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: HoursOfOperations
        public async Task<ActionResult> Index()
        {
            var hoursOfOperations = db.HoursOfOperations.Include(h => h.Location);
            return View(await hoursOfOperations.ToListAsync());
        }

        // GET: HoursOfOperations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoursOfOperation hoursOfOperation = await db.HoursOfOperations.FindAsync(id);
            if (hoursOfOperation == null)
            {
                return HttpNotFound();
            }
            return View(hoursOfOperation);
        }

        // GET: HoursOfOperations/Create
        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "StreetAddress1");
            return View();
        }

        // POST: HoursOfOperations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HoursOfOperationID,DayOfWeek,TimeOpen,LocationID")] HoursOfOperation hoursOfOperation)
        {
            if (ModelState.IsValid)
            {
                db.HoursOfOperations.Add(hoursOfOperation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "StreetAddress1", hoursOfOperation.LocationID);
            return View(hoursOfOperation);
        }

        // GET: HoursOfOperations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoursOfOperation hoursOfOperation = await db.HoursOfOperations.FindAsync(id);
            if (hoursOfOperation == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "StreetAddress1", hoursOfOperation.LocationID);
            return View(hoursOfOperation);
        }

        // POST: HoursOfOperations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HoursOfOperationID,DayOfWeek,TimeOpen,LocationID")] HoursOfOperation hoursOfOperation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoursOfOperation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "StreetAddress1", hoursOfOperation.LocationID);
            return View(hoursOfOperation);
        }

        // GET: HoursOfOperations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoursOfOperation hoursOfOperation = await db.HoursOfOperations.FindAsync(id);
            if (hoursOfOperation == null)
            {
                return HttpNotFound();
            }
            return View(hoursOfOperation);
        }

        // POST: HoursOfOperations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HoursOfOperation hoursOfOperation = await db.HoursOfOperations.FindAsync(id);
            db.HoursOfOperations.Remove(hoursOfOperation);
            await db.SaveChangesAsync();
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
