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
    public class IdeaVotesController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: IdeaVotes
        public async Task<ActionResult> Index()
        {
            var ideaVotes = db.IdeaVotes.Include(i => i.Idea);
            return View(await ideaVotes.ToListAsync());
        }

        // GET: IdeaVotes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaVote ideaVote = await db.IdeaVotes.FindAsync(id);
            if (ideaVote == null)
            {
                return HttpNotFound();
            }
            return View(ideaVote);
        }

        // GET: IdeaVotes/Create
        public ActionResult Create()
        {
            ViewBag.SolutionID = new SelectList(db.Ideas, "IdeaID", "UserID");
            return View();
        }
      
        // POST: IdeaVotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VoteID,UserID,upVote,CreationDate,SolutionID")] IdeaVote ideaVote)
        {
            if (ModelState.IsValid)
            {
                db.IdeaVotes.Add(ideaVote);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SolutionID = new SelectList(db.Ideas, "IdeaID", "UserID", ideaVote.SolutionID);
            return View(ideaVote);
        }

        // GET: IdeaVotes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaVote ideaVote = await db.IdeaVotes.FindAsync(id);
            if (ideaVote == null)
            {
                return HttpNotFound();
            }
            ViewBag.SolutionID = new SelectList(db.Ideas, "IdeaID", "UserID", ideaVote.SolutionID);
            return View(ideaVote);
        }

        // POST: IdeaVotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VoteID,UserID,upVote,CreationDate,SolutionID")] IdeaVote ideaVote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ideaVote).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SolutionID = new SelectList(db.Ideas, "IdeaID", "UserID", ideaVote.SolutionID);
            return View(ideaVote);
        }

        // GET: IdeaVotes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaVote ideaVote = await db.IdeaVotes.FindAsync(id);
            if (ideaVote == null)
            {
                return HttpNotFound();
            }
            return View(ideaVote);
        }

        // POST: IdeaVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IdeaVote ideaVote = await db.IdeaVotes.FindAsync(id);
            db.IdeaVotes.Remove(ideaVote);
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
