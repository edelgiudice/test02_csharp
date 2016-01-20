using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRApplicationTool.Models
{
    public class ToolConfiguration
    {
        // singelton 
        private static ToolConfiguration instance;

        private ToolConfiguration() { }

        public static ToolConfiguration Instance
       {
          get 
          {
             if (instance == null)
             {
                 instance = new ToolConfiguration()
                 {
                    StartHour =0,
                    StartMin =0,
                    EndHour=23,
                    EndMin=59
                    
                 };
             }
             return instance;
          }
       }
        [Display(Name="Start Hour")]
        [Range(typeof(int), "0", "23")]
        public int StartHour { get; set; }
        
        [Display(Name = "Start Min")]
        [Range(typeof(int), "0", "59")]
        public int StartMin { get; set; }

        [Display(Name = "End Hour")]
        [Range(typeof(int), "0", "23")]
        public int EndHour { get; set; }
        
        [Display(Name = "End Min")]
        [Range(typeof(int), "0", "59")]
        public int EndMin { get; set; }
    }
}