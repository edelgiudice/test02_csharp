using HRApplicationTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        
        public ActionResult SendReport()
        {
            var fromAddress = new MailAddress("edguktest@gmail.com");
            var fromPassword = "ed220709";
            var toAddress = new MailAddress("emilio.delgiudice@gmail.com");

            string subject = "subject";
            string body = "body";

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })


            smtp.Send(message);
           
            return RedirectToAction("Index","Home");
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                ToolConfiguration.Instance.StartMin = collection["StartMin"] ==null ? ToolConfiguration.Instance.StartMin : Convert.ToInt32(collection["StartMin"]);
                ToolConfiguration.Instance.StartHour = collection["StartHour"] == null ? ToolConfiguration.Instance.StartHour : Convert.ToInt32(collection["StartHour"]);
                ToolConfiguration.Instance.EndMin = collection["EndMin"] == null ? ToolConfiguration.Instance.EndMin : Convert.ToInt32(collection["EndMin"]);
                ToolConfiguration.Instance.EndHour = collection["EndHour"] == null ? ToolConfiguration.Instance.EndHour : Convert.ToInt32(collection["EndHour"]);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
