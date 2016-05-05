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
    public class SolutionVoteModelsController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: SolutionVoteModels
        public ActionResult Index()
        {
            return View(db.SolutionVotes.ToList());
        }

        // GET: SolutionVoteModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolutionVoteModel solutionVoteModel = db.SolutionVotes.Find(id);
            if (solutionVoteModel == null)
            {
                return HttpNotFound();
            }
            return View(solutionVoteModel);
        }

        // GET: SolutionVoteModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolutionVoteModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UID,SID,upVote")] SolutionVoteModel solutionVoteModel)
        {
            if (ModelState.IsValid)
            {
                db.SolutionVotes.Add(solutionVoteModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(solutionVoteModel);
        }

        // GET: SolutionVoteModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolutionVoteModel solutionVoteModel = db.SolutionVotes.Find(id);
            if (solutionVoteModel == null)
            {
                return HttpNotFound();
            }
            return View(solutionVoteModel);
        }

        // POST: SolutionVoteModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UID,SID,upVote")] SolutionVoteModel solutionVoteModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solutionVoteModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solutionVoteModel);
        }

        // GET: SolutionVoteModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolutionVoteModel solutionVoteModel = db.SolutionVotes.Find(id);
            if (solutionVoteModel == null)
            {
                return HttpNotFound();
            }
            return View(solutionVoteModel);
        }

        // POST: SolutionVoteModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolutionVoteModel solutionVoteModel = db.SolutionVotes.Find(id);
            db.SolutionVotes.Remove(solutionVoteModel);
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
