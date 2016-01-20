namespace HRApplicationTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationApplicationSkill : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SkillModels", newName: "SkillModelApplicationModels");
            DropForeignKey("dbo.SkillModels", "SkillModel_ID", "dbo.SkillModels");
            DropForeignKey("dbo.SkillModels", "ApplicationModel_ID", "dbo.ApplicationModels");
            DropIndex("dbo.SkillModels", new[] { "SkillModel_ID" });
            DropIndex("dbo.SkillModels", new[] { "ApplicationModel_ID" });
            CreateIndex("dbo.SkillModelApplicationModels", "SkillModel_ID");
            CreateIndex("dbo.SkillModelApplicationModels", "ApplicationModel_ID");
            AddForeignKey("dbo.SkillModelApplicationModels", "SkillModel_ID", "dbo.SkillModels", "ID", cascadeDelete: true);
            AddForeignKey("dbo.SkillModelApplicationModels", "ApplicationModel_ID", "dbo.ApplicationModels", "ID", cascadeDelete: true);
            DropColumn("dbo.SkillModels", "SkillModel_ID");
            DropColumn("dbo.SkillModels", "ApplicationModel_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SkillModels", "ApplicationModel_ID", c => c.Int());
            AddColumn("dbo.SkillModels", "SkillModel_ID", c => c.Int());
            DropForeignKey("dbo.SkillModelApplicationModels", "ApplicationModel_ID", "dbo.ApplicationModels");
            DropForeignKey("dbo.SkillModelApplicationModels", "SkillModel_ID", "dbo.SkillModels");
            DropIndex("dbo.SkillModelApplicationModels", new[] { "ApplicationModel_ID" });
            DropIndex("dbo.SkillModelApplicationModels", new[] { "SkillModel_ID" });
            CreateIndex("dbo.SkillModels", "ApplicationModel_ID");
            CreateIndex("dbo.SkillModels", "SkillModel_ID");
            AddForeignKey("dbo.SkillModels", "ApplicationModel_ID", "dbo.ApplicationModels", "ID");
            AddForeignKey("dbo.SkillModels", "SkillModel_ID", "dbo.SkillModels", "ID");
            RenameTable(name: "dbo.SkillModelApplicationModels", newName: "SkillModels");
        }
    }
}
