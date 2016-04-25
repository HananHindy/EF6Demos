namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeachersTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Schema1.Students", newName: "Student");
            MoveTable(name: "Schema1.Student", newSchema: "DemoSchema");
            CreateTable(
                "DemoSchema.Teacher",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Title = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("DemoSchema.Teacher");
            MoveTable(name: "DemoSchema.Student", newSchema: "Schema1");
            RenameTable(name: "Schema1.Student", newName: "Students");
        }
    }
}
