using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRApplicationTool.Models
{
    public class ApplicationModel
    {
        public int ID { set; get; }
        [Display(Name ="Registration Time")]
        public DateTime RegistrationTime { get; set; }
        [Display(Name="First Name")]
        public string FirstName { set; get; }
        public string Surname { set; get; }
        public string Address { set; get; }
        public virtual ICollection<SkillModel> Skills { get; set; }
    }
}