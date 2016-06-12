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
    public class BusinessCategoriesController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: BusinessCategories
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var businessCategories = db.BusinessCategories.Include(b => b.Company);
            return View(await businessCategories.ToListAsync());
        }

        // GET: BusinessCategories/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCategory businessCategory = await db.BusinessCategories.FindAsync(id);
            if (businessCategory == null)
            {
                return HttpNotFound();
            }
            return View(businessCategory);
        }

        // GET: BusinessCategories/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: BusinessCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BusinessCategoryID,Title,Description,CompanyID")] BusinessCategory businessCategory)
        {
            if (ModelState.IsValid)
            {
                db.BusinessCategories.Add(businessCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", businessCategory.CompanyID);
            return View(businessCategory);
        }

        // GET: BusinessCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCategory businessCategory = await db.BusinessCategories.FindAsync(id);
            if (businessCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", businessCategory.CompanyID);
            return View(businessCategory);
        }

        // POST: BusinessCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BusinessCategoryID,Title,Description,CompanyID")] BusinessCategory businessCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", businessCategory.CompanyID);
            return View(businessCategory);
        }

        // GET: BusinessCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCategory businessCategory = await db.BusinessCategories.FindAsync(id);
            if (businessCategory == null)
            {
                return HttpNotFound();
            }
            return View(businessCategory);
        }

        // POST: BusinessCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BusinessCategory businessCategory = await db.BusinessCategories.FindAsync(id);
            db.BusinessCategories.Remove(businessCategory);
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
