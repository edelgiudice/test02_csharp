using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApplicationTool.Models
{
    public class SkillModel
    {
        public SkillModel()
        {
            Applications = new HashSet<ApplicationModel>();
        }
        public int SkillID { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<ApplicationModel> Applications { get; set; }
    }
}