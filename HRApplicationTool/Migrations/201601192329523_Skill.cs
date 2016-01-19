namespace HRApplicationTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Skill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkillModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SkillModels");
        }
    }
}
