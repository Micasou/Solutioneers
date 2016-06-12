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
    public class IdeasController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: Ideas
        public async Task<ActionResult> Index()
        {
            var ideas = db.Ideas.Include(i => i.BusinessChannel);
            return View(await ideas.ToListAsync());
        }

        // GET: Ideas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = await db.Ideas.FindAsync(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // GET: Ideas/Create
        public ActionResult Create()
        {
            ViewBag.ChannelID = new SelectList(db.BusinessChannels, "BusinessChannelID", "Title");
            return View();
        }

        // POST: Ideas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdeaID,UserID,CreationDate,Title,Description,ChannelID")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                db.Ideas.Add(idea);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ChannelID = new SelectList(db.BusinessChannels, "BusinessChannelID", "Title", idea.ChannelID);
            return View(idea);
        }

        // GET: Ideas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = await db.Ideas.FindAsync(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChannelID = new SelectList(db.BusinessChannels, "BusinessChannelID", "Title", idea.ChannelID);
            return View(idea);
        }

        // POST: Ideas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdeaID,UserID,CreationDate,Title,Description,ChannelID")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idea).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ChannelID = new SelectList(db.BusinessChannels, "BusinessChannelID", "Title", idea.ChannelID);
            return View(idea);
        }

        // GET: Ideas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = await db.Ideas.FindAsync(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Idea idea = await db.Ideas.FindAsync(id);
            db.Ideas.Remove(idea);
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
