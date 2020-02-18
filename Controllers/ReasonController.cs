using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMVCApp;

namespace MyMVCApp.Controllers
{
    public class ReasonController : Controller
    {
        private MyData db = new MyData();

        // GET: Reason
        public async Task<ActionResult> Index()
        {
            return View(await db.Reasons.ToListAsync());
        }

        // GET: Reason/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reason reason = await db.Reasons.FindAsync(id);
            if (reason == null)
            {
                return HttpNotFound();
            }
            return View(reason);
        }

        // GET: Reason/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reason/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Reason1")] Reason reason)
        {
            if (ModelState.IsValid)
            {
                db.Reasons.Add(reason);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(reason);
        }

        // GET: Reason/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reason reason = await db.Reasons.FindAsync(id);
            if (reason == null)
            {
                return HttpNotFound();
            }
            return View(reason);
        }

        // POST: Reason/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Reason1")] Reason reason)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reason).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reason);
        }

        // GET: Reason/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reason reason = await db.Reasons.FindAsync(id);
            if (reason == null)
            {
                return HttpNotFound();
            }
            return View(reason);
        }

        // POST: Reason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reason reason = await db.Reasons.FindAsync(id);
            db.Reasons.Remove(reason);
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
