namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RowVersionToClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("DemoSchema.Class", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("DemoSchema.Class", "RowVersion");
        }
    }
}
