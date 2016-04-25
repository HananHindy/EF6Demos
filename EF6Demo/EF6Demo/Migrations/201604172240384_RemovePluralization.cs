namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePluralization : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Classes", newName: "Class");
            RenameTable(name: "dbo.Students", newName: "Student");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Student", newName: "Students");
            RenameTable(name: "dbo.Class", newName: "Classes");
        }
    }
}
