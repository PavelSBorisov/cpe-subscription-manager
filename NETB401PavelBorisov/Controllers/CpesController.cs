using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NETB401PavelBorisov.Models;
using System.Data.Entity.Infrastructure;

namespace NETB401PavelBorisov.Controllers
{
    [Authorize]
    public class CpesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CpesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Cpes
        public async Task<ActionResult> Index()
        {
            return View(await _context.Cpes.ToListAsync());
        }

        // GET: Cpes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cpes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CpeId,SubscriberEmails")] Cpe cpe)
        {
            if (ModelState.IsValid)
            {
                _context.Cpes.Add(cpe);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cpe);
        }

        // GET: Cpes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cpe cpe = await _context.Cpes.FindAsync(id);
            if (cpe == null)
            {
                return HttpNotFound();
            }
            return View(cpe);
        }

        // POST: Cpes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CpeId,SubscriberEmails")] Cpe cpe)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(cpe).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cpe);
        }

        // GET: Cpes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cpe cpe = await _context.Cpes.FindAsync(id);
            if (cpe == null)
            {
                return HttpNotFound();
            }

            return View(cpe);
        }

        // POST: Cpes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cpe cpe = await _context.Cpes.FindAsync(id);
            _context.Cpes.Remove(cpe);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Cpes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cpe cpe = await _context.Cpes.FindAsync(id);
            if (cpe == null)
            {
                return HttpNotFound();
            }

            return View(cpe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CpeExists(int id)
        {
            return _context.Cpes.Any(e => e.Id == id);
        }
    }
}
