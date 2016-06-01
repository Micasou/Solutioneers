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
    public class ChannelVotesController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: ChannelVotes
        public async Task<ActionResult> Index()
        {
            var channelVotes = db.ChannelVotes.Include(c => c.Channel);
            return View(await channelVotes.ToListAsync());
        }

        // GET: ChannelVotes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelVote channelVote = await db.ChannelVotes.FindAsync(id);
            if (channelVote == null)
            {
                return HttpNotFound();
            }
            return View(channelVote);
        }

        // GET: ChannelVotes/Create
        public ActionResult Create()
        {
            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title");
            return View();
        }

        // POST: ChannelVotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VoteID,UserID,upVote,ChannelID")] ChannelVote channelVote)
        {
            if (ModelState.IsValid)
            {
                db.ChannelVotes.Add(channelVote);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title", channelVote.ChannelID);
            return View(channelVote);
        }

        // GET: ChannelVotes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelVote channelVote = await db.ChannelVotes.FindAsync(id);
            if (channelVote == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title", channelVote.ChannelID);
            return View(channelVote);
        }

        // POST: ChannelVotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VoteID,UserID,upVote,ChannelID")] ChannelVote channelVote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(channelVote).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ChannelID = new SelectList(db.Channels, "ChannelID", "Title", channelVote.ChannelID);
            return View(channelVote);
        }

        // GET: ChannelVotes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelVote channelVote = await db.ChannelVotes.FindAsync(id);
            if (channelVote == null)
            {
                return HttpNotFound();
            }
            return View(channelVote);
        }

        // POST: ChannelVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ChannelVote channelVote = await db.ChannelVotes.FindAsync(id);
            db.ChannelVotes.Remove(channelVote);
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
