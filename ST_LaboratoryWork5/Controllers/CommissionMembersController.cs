using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ST_LaboratoryWork5.Models;

namespace ST_LaboratoryWork5.Controllers
{
    public class CommissionMembersController : Controller
    {
        private ExaminationСommissionContext db = new ExaminationСommissionContext();

        // GET: CommissionMembers
        public async Task<ActionResult> Index()
        {
            return View(await db.CommissionMembers.ToListAsync());
        }

        // GET: CommissionMembers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommissionMember commissionMember = await db.CommissionMembers.FindAsync(id);
            if (commissionMember == null)
            {
                return HttpNotFound();
            }
            return View(commissionMember);
        }

        // GET: CommissionMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommissionMembers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Duty")] CommissionMember commissionMember)
        {
            if (ModelState.IsValid)
            {
                db.CommissionMembers.Add(commissionMember);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(commissionMember);
        }

        // GET: CommissionMembers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommissionMember commissionMember = await db.CommissionMembers.FindAsync(id);
            if (commissionMember == null)
            {
                return HttpNotFound();
            }
            return View(commissionMember);
        }

        // POST: CommissionMembers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Duty")] CommissionMember commissionMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commissionMember).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(commissionMember);
        }

        // GET: CommissionMembers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommissionMember commissionMember = await db.CommissionMembers.FindAsync(id);
            if (commissionMember == null)
            {
                return HttpNotFound();
            }
            return View(commissionMember);
        }

        // POST: CommissionMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CommissionMember commissionMember = await db.CommissionMembers.FindAsync(id);
            db.CommissionMembers.Remove(commissionMember);
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
