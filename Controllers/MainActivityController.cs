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
    public class MainActivityController : Controller
    {
        private MyData db = new MyData();

        // GET: MainActivity
        public async Task<ActionResult> Index()
        {
            return View(await db.MainActivities.ToListAsync());
        }

        // GET: MainActivity/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainActivity mainActivity = await db.MainActivities.FindAsync(id);
            if (mainActivity == null)
            {
                return HttpNotFound();
            }
            return View(mainActivity);
        }

        // GET: MainActivity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainActivity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,MainActivity1")] MainActivity mainActivity)
        {
            if (ModelState.IsValid)
            {
                db.MainActivities.Add(mainActivity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mainActivity);
        }

        // GET: MainActivity/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainActivity mainActivity = await db.MainActivities.FindAsync(id);
            if (mainActivity == null)
            {
                return HttpNotFound();
            }
            return View(mainActivity);
        }

        // POST: MainActivity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,MainActivity1")] MainActivity mainActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainActivity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mainActivity);
        }

        // GET: MainActivity/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainActivity mainActivity = await db.MainActivities.FindAsync(id);
            if (mainActivity == null)
            {
                return HttpNotFound();
            }
            return View(mainActivity);
        }

        // POST: MainActivity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MainActivity mainActivity = await db.MainActivities.FindAsync(id);
            db.MainActivities.Remove(mainActivity);
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
