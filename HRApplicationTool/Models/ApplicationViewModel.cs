using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRApplicationTool.Models
{
    public class ApplicationViewModel
    {
        public SelectList ListOfSkills { set; get; }
        public SelectList SelectedSkills { set; get; }
        public ApplicationModel Application { set; get; }

        public ApplicationViewModel() {  }
        public ApplicationViewModel(IEnumerable<SkillModel> skills, ApplicationModel application=null)
        {
            ListOfSkills = new SelectList(skills, "SkillID", "SkillName");
            Application = application ?? new ApplicationModel();
        }
    }
}