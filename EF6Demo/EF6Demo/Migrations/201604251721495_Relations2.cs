namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relations2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "DemoSchema.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(maxLength: 100),
                        Student2_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("DemoSchema.Person", t => t.Student2_ID)
                .Index(t => t.Student2_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("DemoSchema.Course", "Student2_ID", "DemoSchema.Person");
            DropIndex("DemoSchema.Course", new[] { "Student2_ID" });
            DropTable("DemoSchema.Course");
        }
    }
}
