namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchemaChange2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "DemoSchema.Student", newName: "Students");
            MoveTable(name: "DemoSchema.Students", newSchema: "Schema1");
        }
        
        public override void Down()
        {
            MoveTable(name: "Schema1.Students", newSchema: "DemoSchema");
            RenameTable(name: "DemoSchema.Students", newName: "Student");
        }
    }
}
