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
    public class IdeaCommentsController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: IdeaComments
        public async Task<ActionResult> Index()
        {
            var ideaComments = db.IdeaComments.Include(i => i.BusinessChannel);
            return View(await ideaComments.ToListAsync());
        }

        // GET: IdeaComments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaComment ideaComment = await db.IdeaComments.FindAsync(id);
            if (ideaComment == null)
            {
                return HttpNotFound();
            }
            return View(ideaComment);
        }

        // GET: IdeaComments/Create
        public ActionResult Create()
        {
            ViewBag.BusinessChannelID = new SelectList(db.BusinessChannels, "BusinessChannelID", "Title");
            return View();
        }

        // POST: IdeaComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CommentID,UserID,UserComment,CreationDate,BusinessChannelID")] IdeaComment ideaComment)
        {
            if (ModelState.IsValid)
            {
                db.IdeaComments.Add(ideaComment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessChannelID = new SelectList(db.BusinessChannels, "BusinessChannelID", "Title", ideaComment.BusinessChannelID);
            return View(ideaComment);
        }

        // GET: IdeaComments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaComment ideaComment = await db.IdeaComments.FindAsync(id);
            if (ideaComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessChannelID = new SelectList(db.BusinessChannels, "BusinessChannelID", "Title", ideaComment.BusinessChannelID);
            return View(ideaComment);
        }

        // POST: IdeaComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CommentID,UserID,UserComment,CreationDate,BusinessChannelID")] IdeaComment ideaComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ideaComment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessChannelID = new SelectList(db.BusinessChannels, "BusinessChannelID", "Title", ideaComment.BusinessChannelID);
            return View(ideaComment);
        }

        // GET: IdeaComments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaComment ideaComment = await db.IdeaComments.FindAsync(id);
            if (ideaComment == null)
            {
                return HttpNotFound();
            }
            return View(ideaComment);
        }

        // POST: IdeaComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IdeaComment ideaComment = await db.IdeaComments.FindAsync(id);
            db.IdeaComments.Remove(ideaComment);
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
