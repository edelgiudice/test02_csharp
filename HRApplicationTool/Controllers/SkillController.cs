using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRApplicationTool.Models;

namespace HRApplicationTool.Controllers
{
    public class SkillController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Skill/
        public async Task<ActionResult> Index()
        {
            return View(await db.SkillModels.ToListAsync());
        }

        // GET: /Skill/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillModel skillmodel = await db.SkillModels.FindAsync(id);
            if (skillmodel == null)
            {
                return HttpNotFound();
            }
            return View(skillmodel);
        }

        // GET: /Skill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Skill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,SkillName")] SkillModel skillmodel)
        {
            if (ModelState.IsValid)
            {
                db.SkillModels.Add(skillmodel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(skillmodel);
        }

        // GET: /Skill/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillModel skillmodel = await db.SkillModels.FindAsync(id);
            if (skillmodel == null)
            {
                return HttpNotFound();
            }
            return View(skillmodel);
        }

        // POST: /Skill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,SkillName")] SkillModel skillmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skillmodel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(skillmodel);
        }

        // GET: /Skill/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillModel skillmodel = await db.SkillModels.FindAsync(id);
            if (skillmodel == null)
            {
                return HttpNotFound();
            }
            return View(skillmodel);
        }

        // POST: /Skill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SkillModel skillmodel = await db.SkillModels.FindAsync(id);
            db.SkillModels.Remove(skillmodel);
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
