namespace HRApplicationTool.Migrations
{
    using HRApplicationTool.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HRApplicationTool.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HRApplicationTool.Models.ApplicationDbContext";
        }

        protected override void Seed(HRApplicationTool.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                // Add missing roles
                var role = roleManager.FindByName("Admin");
                if (role == null)
                {
                    role = new IdentityRole("Admin");
                    roleManager.Create(role);
                }

                // Create test users
                var user = userManager.FindByName("admin");
                if (user == null)
                {
                    var newUser = new ApplicationUser()
                    {
                        UserName = "admin",
                    };
                    userManager.Create(newUser, "Password1!");
                    userManager.AddToRole(newUser.Id, "Admin");
                }
            }
            if (!context.SkillModels.Any())
            {
                context.SkillModels.Add(new SkillModel() { SkillName = "C#" });
                context.SkillModels.Add(new SkillModel() { SkillName = "Python" });
                context.SkillModels.Add(new SkillModel() { SkillName = "C++" });
                context.SkillModels.Add(new SkillModel() { SkillName = "Ruby" });
                context.SkillModels.Add(new SkillModel() { SkillName = "C" });
                context.SkillModels.Add(new SkillModel() { SkillName = "C#" });
                context.SkillModels.Add(new SkillModel() { SkillName = "PHP" });
                context.SkillModels.Add(new SkillModel() { SkillName = "Go" });
                context.SkillModels.Add(new SkillModel() { SkillName = "Scala" });
                context.SkillModels.Add(new SkillModel() { SkillName = "Perl" });
                context.SkillModels.Add(new SkillModel() { SkillName = "Objective C" });
            }
            
        }
    }
}
