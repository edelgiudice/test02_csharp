namespace HRApplicationTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Application : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegistrationTime = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        Surname = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.SkillModels", "ApplicationModel_ID", c => c.Int());
            CreateIndex("dbo.SkillModels", "ApplicationModel_ID");
            AddForeignKey("dbo.SkillModels", "ApplicationModel_ID", "dbo.ApplicationModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkillModels", "ApplicationModel_ID", "dbo.ApplicationModels");
            DropIndex("dbo.SkillModels", new[] { "ApplicationModel_ID" });
            DropColumn("dbo.SkillModels", "ApplicationModel_ID");
            DropTable("dbo.ApplicationModels");
        }
    }
}
