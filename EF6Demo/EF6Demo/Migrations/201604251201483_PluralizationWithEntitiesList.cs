namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PluralizationWithEntitiesList : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Class", newName: "MyClass");
            RenameTable(name: "dbo.Student", newName: "Students");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Students", newName: "Student");
            RenameTable(name: "dbo.MyClass", newName: "Class");
        }
    }
}
