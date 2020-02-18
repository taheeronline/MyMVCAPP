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
    public class SubActivityController : Controller
    {
        private MyData db = new MyData();

        // GET: SubActivity
        public async Task<ActionResult> Index()
        {
            var subActivities = db.SubActivities.Include(s => s.MainActivity);
            return View(await subActivities.ToListAsync());
        }

        // GET: SubActivity/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubActivity subActivity = await db.SubActivities.FindAsync(id);
            if (subActivity == null)
            {
                return HttpNotFound();
            }
            return View(subActivity);
        }

        // GET: SubActivity/Create
        public ActionResult Create()
        {
            ViewBag.IDMA = new SelectList(db.MainActivities, "ID", "MainActivity1");
            return View();
        }

        // POST: SubActivity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,SubActivity1,IDMA")] SubActivity subActivity)
        {
            if (ModelState.IsValid)
            {
                db.SubActivities.Add(subActivity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDMA = new SelectList(db.MainActivities, "ID", "MainActivity1", subActivity.IDMA);
            return View(subActivity);
        }

        // GET: SubActivity/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubActivity subActivity = await db.SubActivities.FindAsync(id);
            if (subActivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMA = new SelectList(db.MainActivities, "ID", "MainActivity1", subActivity.IDMA);
            return View(subActivity);
        }

        // POST: SubActivity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,SubActivity1,IDMA")] SubActivity subActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subActivity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDMA = new SelectList(db.MainActivities, "ID", "MainActivity1", subActivity.IDMA);
            return View(subActivity);
        }

        // GET: SubActivity/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubActivity subActivity = await db.SubActivities.FindAsync(id);
            if (subActivity == null)
            {
                return HttpNotFound();
            }
            return View(subActivity);
        }

        // POST: SubActivity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SubActivity subActivity = await db.SubActivities.FindAsync(id);
            db.SubActivities.Remove(subActivity);
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
