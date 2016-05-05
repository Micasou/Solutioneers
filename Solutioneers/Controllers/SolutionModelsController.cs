using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Solutioneers.DAL;
using Solutioneers.Models;

namespace Solutioneers.Controllers
{
    public class SolutionModelsController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: SolutionModels
        public ActionResult Index()
        {
            return View(db.Solutions.ToList());
        }

        // GET: SolutionModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolutionModel solutionModel = db.Solutions.Find(id);
            if (solutionModel == null)
            {
                return HttpNotFound();
            }
            return View(solutionModel);
        }

        // GET: SolutionModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolutionModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UID,PID,Title,Description")] SolutionModel solutionModel)
        {
            if (ModelState.IsValid)
            {
                db.Solutions.Add(solutionModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(solutionModel);
        }

        // GET: SolutionModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolutionModel solutionModel = db.Solutions.Find(id);
            if (solutionModel == null)
            {
                return HttpNotFound();
            }
            return View(solutionModel);
        }

        // POST: SolutionModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UID,PID,Title,Description")] SolutionModel solutionModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solutionModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solutionModel);
        }

        // GET: SolutionModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolutionModel solutionModel = db.Solutions.Find(id);
            if (solutionModel == null)
            {
                return HttpNotFound();
            }
            return View(solutionModel);
        }

        // POST: SolutionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolutionModel solutionModel = db.Solutions.Find(id);
            db.Solutions.Remove(solutionModel);
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
