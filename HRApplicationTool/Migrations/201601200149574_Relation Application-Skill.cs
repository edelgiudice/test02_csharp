namespace HRApplicationTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationApplicationSkill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SkillModels", "SkillModel_ID", c => c.Int());
            CreateIndex("dbo.SkillModels", "SkillModel_ID");
            AddForeignKey("dbo.SkillModels", "SkillModel_ID", "dbo.SkillModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkillModels", "SkillModel_ID", "dbo.SkillModels");
            DropIndex("dbo.SkillModels", new[] { "SkillModel_ID" });
            DropColumn("dbo.SkillModels", "SkillModel_ID");
        }
    }
}
