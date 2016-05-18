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
    public class SolutionsController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: Solutions
        public async Task<ActionResult> Index()
        {
            var solutions = db.Solutions.Include(s => s.Channel).Include(s => s.Problem);
            return View(await solutions.ToListAsync());
        }

        // GET: Solutions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solution solution = await db.Solutions.FindAsync(id);
            if (solution == null)
            {
                return HttpNotFound();
            }
            return View(solution);
        }

        // GET: Solutions/Create
        public ActionResult Create()
        {
            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title");
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "Title");
            return View();
        }

        // POST: Solutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SolutionID,UserID,ProblemID,ChannelID,Title,Description")] Solution solution)
        {
            if (ModelState.IsValid)
            {
                db.Solutions.Add(solution);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title", solution.ChannelID);
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "Title", solution.ProblemID);
            return View(solution);
        }

        // GET: Solutions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solution solution = await db.Solutions.FindAsync(id);
            if (solution == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title", solution.ChannelID);
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "Title", solution.ProblemID);
            return View(solution);
        }

        // POST: Solutions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SolutionID,UserID,ProblemID,ChannelID,Title,Description")] Solution solution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solution).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title", solution.ChannelID);
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "Title", solution.ProblemID);
            return View(solution);
        }

        // GET: Solutions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solution solution = await db.Solutions.FindAsync(id);
            if (solution == null)
            {
                return HttpNotFound();
            }
            return View(solution);
        }

        // POST: Solutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Solution solution = await db.Solutions.FindAsync(id);
            db.Solutions.Remove(solution);
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
