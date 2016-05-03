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

namespace Solutioneers
{
    public class GroupModelsController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: GroupModels
        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }

        // GET: GroupModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel groupModel = db.Groups.Find(id);
            if (groupModel == null)
            {
                return HttpNotFound();
            }
            return View(groupModel);
        }

        // GET: GroupModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GID,Title,Description")] GroupModel groupModel)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(groupModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupModel);
        }

        // GET: GroupModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel groupModel = db.Groups.Find(id);
            if (groupModel == null)
            {
                return HttpNotFound();
            }
            return View(groupModel);
        }

        // POST: GroupModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GID,Title,Description")] GroupModel groupModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupModel);
        }

        // GET: GroupModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupModel groupModel = db.Groups.Find(id);
            if (groupModel == null)
            {
                return HttpNotFound();
            }
            return View(groupModel);
        }

        // POST: GroupModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupModel groupModel = db.Groups.Find(id);
            db.Groups.Remove(groupModel);
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
