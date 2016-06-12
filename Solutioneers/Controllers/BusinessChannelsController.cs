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
    public class BusinessChannelsController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: BusinessChannels
        public async Task<ActionResult> Index()
        {
            var businessChannels = db.BusinessChannels.Include(b => b.Category);
            return View(await businessChannels.ToListAsync());
        }

        // GET: BusinessChannels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessChannel businessChannel = await db.BusinessChannels.FindAsync(id);
            if (businessChannel == null)
            {
                return HttpNotFound();
            }
            return View(businessChannel);
        }

        // GET: BusinessChannels/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Title");
            return View();
        }

        // POST: BusinessChannels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BusinessChannelID,CategoryID,Title,Description,CreationDate")] BusinessChannel businessChannel)
        {
            if (ModelState.IsValid)
            {
                db.BusinessChannels.Add(businessChannel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Title", businessChannel.CategoryID);
            return View(businessChannel);
        }

        // GET: BusinessChannels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessChannel businessChannel = await db.BusinessChannels.FindAsync(id);
            if (businessChannel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Title", businessChannel.CategoryID);
            return View(businessChannel);
        }

        // POST: BusinessChannels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BusinessChannelID,CategoryID,Title,Description,CreationDate")] BusinessChannel businessChannel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessChannel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Title", businessChannel.CategoryID);
            return View(businessChannel);
        }

        // GET: BusinessChannels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessChannel businessChannel = await db.BusinessChannels.FindAsync(id);
            if (businessChannel == null)
            {
                return HttpNotFound();
            }
            return View(businessChannel);
        }

        // POST: BusinessChannels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BusinessChannel businessChannel = await db.BusinessChannels.FindAsync(id);
            db.BusinessChannels.Remove(businessChannel);
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
