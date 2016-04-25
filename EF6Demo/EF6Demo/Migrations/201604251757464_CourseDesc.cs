namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseDesc : DbMigration
    {
        public override void Up()
        {
            AddColumn("DemoSchema.Course", "CourseDescription", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("DemoSchema.Course", "CourseDescription");
        }
    }
}
