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
    public class ProblemModelsController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: ProblemModels
        public ActionResult Index()
        {
            var problems = db.Problems.Include(p => p.Group);
            return View(problems.ToList());
        }

        // GET: ProblemModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemModel problemModel = db.Problems.Find(id);
            if (problemModel == null)
            {
                return HttpNotFound();
            }
            return View(problemModel);
        }

        // GET: ProblemModels/Create
        public ActionResult Create()
        {
            ViewBag.GID = new SelectList(db.Groups, "GID", "Title");
            return View();
        }

        // POST: ProblemModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UID,PID,GID,Title,Description")] ProblemModel problemModel)
        {
            if (ModelState.IsValid)
            {
                db.Problems.Add(problemModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GID = new SelectList(db.Groups, "GID", "Title", problemModel.GID);
            return View(problemModel);
        }

        // GET: ProblemModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemModel problemModel = db.Problems.Find(id);
            if (problemModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.GID = new SelectList(db.Groups, "GID", "Title", problemModel.GID);
            return View(problemModel);
        }

        // POST: ProblemModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UID,PID,GID,Title,Description")] ProblemModel problemModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problemModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GID = new SelectList(db.Groups, "GID", "Title", problemModel.GID);
            return View(problemModel);
        }

        // GET: ProblemModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemModel problemModel = db.Problems.Find(id);
            if (problemModel == null)
            {
                return HttpNotFound();
            }
            return View(problemModel);
        }

        // POST: ProblemModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProblemModel problemModel = db.Problems.Find(id);
            db.Problems.Remove(problemModel);
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
