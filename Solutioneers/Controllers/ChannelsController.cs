﻿using System;
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
    public class ChannelsController : Controller
    {
        private VotingContext db = new VotingContext();

        // GET: Channels
        public async Task<ActionResult> Index()
        {
            return View(await db.Channels.ToListAsync());
        }

        // GET: Channels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Channel channel = await db.Channels.FindAsync(id);
            if (channel == null)
            {
                return HttpNotFound();
            }
            return View(channel);
        }

        // GET: Channels/Create
        public async Task<ActionResult> Create(Category theCategory)
        {
            if (theCategory == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateChannelFromCategory temp = new CreateChannelFromCategory();
            temp.Category = await db.Categories.FindAsync(theCategory.CategoryID);
            temp.Categories = await db.Categories.ToListAsync();
            if (temp.Category == null || temp.Categories == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        // POST: Channels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ChannelID,UserID,Title,Description,CreationDate")] Channel channel,Category theCategory, int UID)
        {
            if (ModelState.IsValid)
            {
                db.Channels.Add(channel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(channel);
        }

        // GET: Channels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Channel channel = await db.Channels.FindAsync(id);
            if (channel == null)
            {
                return HttpNotFound();
            }
            return View(channel);
        }

        // POST: Channels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ChannelID,UserID,Title,Description,CreationDate")] Channel channel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(channel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(channel);
        }

        // GET: Channels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Channel channel = await db.Channels.FindAsync(id);
            if (channel == null)
            {
                return HttpNotFound();
            }
            return View(channel);
        }

        // POST: Channels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Channel channel = await db.Channels.FindAsync(id);
            db.Channels.Remove(channel);
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
