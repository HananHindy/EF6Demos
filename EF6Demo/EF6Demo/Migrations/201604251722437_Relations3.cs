namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relations3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("DemoSchema.Course", "Student2_ID", "DemoSchema.Person");
            DropIndex("DemoSchema.Course", new[] { "Student2_ID" });
            CreateTable(
                "DemoSchema.CourseStudent2",
                c => new
                    {
                        Course_ID = c.Int(nullable: false),
                        Student2_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_ID, t.Student2_ID })
                .ForeignKey("DemoSchema.Course", t => t.Course_ID, cascadeDelete: true)
                .ForeignKey("DemoSchema.Person", t => t.Student2_ID, cascadeDelete: true)
                .Index(t => t.Course_ID)
                .Index(t => t.Student2_ID);
            
            DropColumn("DemoSchema.Course", "Student2_ID");
        }
        
        public override void Down()
        {
            AddColumn("DemoSchema.Course", "Student2_ID", c => c.Int());
            DropForeignKey("DemoSchema.CourseStudent2", "Student2_ID", "DemoSchema.Person");
            DropForeignKey("DemoSchema.CourseStudent2", "Course_ID", "DemoSchema.Course");
            DropIndex("DemoSchema.CourseStudent2", new[] { "Student2_ID" });
            DropIndex("DemoSchema.CourseStudent2", new[] { "Course_ID" });
            DropTable("DemoSchema.CourseStudent2");
            CreateIndex("DemoSchema.Course", "Student2_ID");
            AddForeignKey("DemoSchema.Course", "Student2_ID", "DemoSchema.Person", "ID");
        }
    }
}
