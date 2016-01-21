using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApplicationTool.Models
{
    public class EmailReport: Email
    {
        public string To { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        
    }
}