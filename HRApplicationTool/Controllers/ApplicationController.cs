﻿using System;
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
    public class ApplicationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Application/
        public async Task<ActionResult> Index()
        {
            return View(await db.ApplicationModels.ToListAsync());
        }

        // GET: /Application/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationModel applicationmodel = await db.ApplicationModels.FindAsync(id);
            if (applicationmodel == null)
            {
                return HttpNotFound();
            }
            return View(applicationmodel);
        }

        // GET: /Application/Create
        public ActionResult Create()
        {
            if(CheckRegistrationTime)
            {
                SetViewBagWithAvailableSkills();
                return View();
            }
            else
            {
                return RedirectToAction("Closed");
            }

        }

        
        public ActionResult Closed()
        {
            return View();
        }

        public ActionResult ApplicationSent()
        {
            return View();
        }

        private void SetViewBagWithAvailableSkills()
        {
            var skills = db.SkillModels.Select(c => new
            {
                SkillID = c.SkillID,
                SkillName = c.SkillName
            }).ToList();
            ViewBag.Skills = new MultiSelectList(skills, "SkillID", "SkillName");
        }

        // POST: /Application/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,RegistrationTime,FirstName,Surname,Address")]ApplicationModel applicationModel, int[] SkillIds)
        {
            SetViewBagWithAvailableSkills();
            if (ModelState.IsValid)
            {
                applicationModel.Skills = db.SkillModels.Where(w => SkillIds.Contains(w.SkillID)).ToList();
                db.ApplicationModels.Add(applicationModel);
                await db.SaveChangesAsync();
                return RedirectToAction("ApplicationSent");
            }

            return View();
        }

        // GET: /Application/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationModel applicationmodel = await db.ApplicationModels.FindAsync(id);
            if (applicationmodel == null)
            {
                return HttpNotFound();
            }
            return View(applicationmodel);
        }

        // POST: /Application/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,RegistrationTime,FirstName,Surname,Address")] ApplicationModel applicationmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationmodel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(applicationmodel);
        }

        // GET: /Application/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationModel applicationmodel = await db.ApplicationModels.FindAsync(id);
            if (applicationmodel == null)
            {
                return HttpNotFound();
            }
            return View(applicationmodel);
        }

        // POST: /Application/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApplicationModel applicationmodel = await db.ApplicationModels.FindAsync(id);
            db.ApplicationModels.Remove(applicationmodel);
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

        public bool CheckRegistrationTime { 
            get
            { 
                return false;
            }
        }
    }
}
