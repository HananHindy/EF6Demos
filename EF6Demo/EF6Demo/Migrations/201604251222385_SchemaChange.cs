namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchemaChange : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Class", newSchema: "DemoSchema");
            MoveTable(name: "dbo.Student", newSchema: "DemoSchema");
        }
        
        public override void Down()
        {
            MoveTable(name: "DemoSchema.Student", newSchema: "dbo");
            MoveTable(name: "DemoSchema.Class", newSchema: "dbo");
        }
    }
}
