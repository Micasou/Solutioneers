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
    [Authorize]
    public class SolutionVotesController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: SolutionVotes
        public async Task<ActionResult> Index()
        {
            var solutionVotes = db.SolutionVotes.Include(s => s.Solution);
            return View(await solutionVotes.ToListAsync());
        }

        // GET: SolutionVotes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolutionVote solutionVote = await db.SolutionVotes.FindAsync(id);
            if (solutionVote == null)
            {
                return HttpNotFound();
            }
            return View(solutionVote);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> Vote(bool theUpVote, int? id, int solutionID, string userName)
        {
            if (id == null)
            {
                return PartialView();
            }
            SolutionVote solutionVote = await db.SolutionVotes.FindAsync(id);
            if (solutionVote == null)
            {
                solutionVote = new SolutionVote();
                solutionVote.CreationDate = DateTime.Now;
                solutionVote.Solution = await db.Solutions.FindAsync(solutionID);
                solutionVote.SolutionID = solutionID;
                solutionVote.UserID = userName;

            }
            else
            {
                solutionVote.upVote = theUpVote;
                db.Entry(solutionVote).State = EntityState.Modified;
            }
            await db.SaveChangesAsync();
            return PartialView(solutionVote);
        }

        // GET: SolutionVotes/Create
        public ActionResult Create()
        {
            ViewBag.SolutionID = new SelectList(db.Solutions, "SolutionID", "Title");
            return View();
        }

        // POST: SolutionVotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VoteID,UserID,upVote,SolutionID")] SolutionVote solutionVote)
        {
            if (ModelState.IsValid)
            {
                db.SolutionVotes.Add(solutionVote);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SolutionID = new SelectList(db.Solutions, "SolutionID", "Title", solutionVote.SolutionID);
            return View(solutionVote);
        }

        // GET: SolutionVotes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolutionVote solutionVote = await db.SolutionVotes.FindAsync(id);
            if (solutionVote == null)
            {
                return HttpNotFound();
            }
            ViewBag.SolutionID = new SelectList(db.Solutions, "SolutionID", "Title", solutionVote.SolutionID);
            return View(solutionVote);
        }

        // POST: SolutionVotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VoteID,UserID,upVote,SolutionID")] SolutionVote solutionVote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solutionVote).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SolutionID = new SelectList(db.Solutions, "SolutionID", "Title", solutionVote.SolutionID);
            return View(solutionVote);
        }

        // GET: SolutionVotes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolutionVote solutionVote = await db.SolutionVotes.FindAsync(id);
            if (solutionVote == null)
            {
                return HttpNotFound();
            }
            return View(solutionVote);
        }

        // POST: SolutionVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SolutionVote solutionVote = await db.SolutionVotes.FindAsync(id);
            db.SolutionVotes.Remove(solutionVote);
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
