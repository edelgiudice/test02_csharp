using HRApplicationTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRApplicationTool.Controllers
{
    public class ToolConfigurationController : Controller
    {
        //
        // GET: /ToolConfiguration/
        public ActionResult Index()
        { 
            return View(ToolConfiguration.Instance); 
        }


        //
        // GET: /ToolConfiguration/Edit/5
        public ActionResult Edit()
        {
            return View(ToolConfiguration.Instance);
        }

        //
        // POST: /ToolConfiguration/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
