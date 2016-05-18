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
    public class ProblemsController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: Problems
        public async Task<ActionResult> Index()
        {
            var problems = db.Problems.Include(p => p.Channel);
            return View(await problems.ToListAsync());
        }

        // GET: Problems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = await db.Problems.FindAsync(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // GET: Problems/Create
        public ActionResult Create()
        {
            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title");
            return View();
        }

        // POST: Problems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProblemID,UserID,ChannelID,Title,Description")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                db.Problems.Add(problem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title", problem.ChannelID);
            return View(problem);
        }

        // GET: Problems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = await db.Problems.FindAsync(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title", problem.ChannelID);
            return View(problem);
        }

        // POST: Problems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProblemID,UserID,ChannelID,Title,Description")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title", problem.ChannelID);
            return View(problem);
        }

        // GET: Problems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = await db.Problems.FindAsync(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Problem problem = await db.Problems.FindAsync(id);
            db.Problems.Remove(problem);
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
