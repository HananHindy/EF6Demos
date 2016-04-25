namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseObj : DbMigration
    {
        public override void Up()
        {
            AddColumn("DemoSchema.Course", "CourseObjective", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("DemoSchema.Course", "CourseObjective");
        }
    }
}
