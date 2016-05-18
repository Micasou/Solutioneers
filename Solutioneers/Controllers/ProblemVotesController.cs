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
    public class ProblemVotesController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: ProblemVotes
        public async Task<ActionResult> Index()
        {
            var problemVotes = db.ProblemVotes.Include(p => p.Problem);
            return View(await problemVotes.ToListAsync());
        }

        // GET: ProblemVotes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemVote problemVote = await db.ProblemVotes.FindAsync(id);
            if (problemVote == null)
            {
                return HttpNotFound();
            }
            return View(problemVote);
        }

        // GET: ProblemVotes/Create
        public ActionResult Create()
        {
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "Title");
            return View();
        }

        // POST: ProblemVotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VoteID,UserID,ProblemID,upVote")] ProblemVote problemVote)
        {
            if (ModelState.IsValid)
            {
                db.ProblemVotes.Add(problemVote);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "Title", problemVote.ProblemID);
            return View(problemVote);
        }

        // GET: ProblemVotes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemVote problemVote = await db.ProblemVotes.FindAsync(id);
            if (problemVote == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "Title", problemVote.ProblemID);
            return View(problemVote);
        }

        // POST: ProblemVotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VoteID,UserID,ProblemID,upVote")] ProblemVote problemVote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problemVote).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProblemID = new SelectList(db.Problems, "ProblemID", "Title", problemVote.ProblemID);
            return View(problemVote);
        }

        // GET: ProblemVotes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemVote problemVote = await db.ProblemVotes.FindAsync(id);
            if (problemVote == null)
            {
                return HttpNotFound();
            }
            return View(problemVote);
        }

        // POST: ProblemVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProblemVote problemVote = await db.ProblemVotes.FindAsync(id);
            db.ProblemVotes.Remove(problemVote);
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
