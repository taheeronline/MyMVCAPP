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
    public class CostCenterController : Controller
    {
        private MyData db = new MyData();

        // GET: CostCenter
        public async Task<ActionResult> Index()
        {
            var costCenters = db.CostCenters.Include(c => c.Project);
            return View(await costCenters.ToListAsync());
        }

        // GET: CostCenter/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostCenter costCenter = await db.CostCenters.FindAsync(id);
            if (costCenter == null)
            {
                return HttpNotFound();
            }
            return View(costCenter);
        }

        // GET: CostCenter/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectCode");
            return View();
        }

        // POST: CostCenter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CostCenter1,ProjectID")] CostCenter costCenter)
        {
            if (ModelState.IsValid)
            {
                db.CostCenters.Add(costCenter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectCode", costCenter.ProjectID);
            return View(costCenter);
        }

        // GET: CostCenter/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostCenter costCenter = await db.CostCenters.FindAsync(id);
            if (costCenter == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectCode", costCenter.ProjectID);
            return View(costCenter);
        }

        // POST: CostCenter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CostCenter1,ProjectID")] CostCenter costCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costCenter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectCode", costCenter.ProjectID);
            return View(costCenter);
        }

        // GET: CostCenter/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostCenter costCenter = await db.CostCenters.FindAsync(id);
            if (costCenter == null)
            {
                return HttpNotFound();
            }
            return View(costCenter);
        }

        // POST: CostCenter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CostCenter costCenter = await db.CostCenters.FindAsync(id);
            db.CostCenters.Remove(costCenter);
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
