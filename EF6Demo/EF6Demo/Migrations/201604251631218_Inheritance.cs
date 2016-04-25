namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inheritance : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "DemoSchema.Teacher", newName: "Person");
            AddColumn("DemoSchema.Person", "Grade", c => c.Int());
            AddColumn("DemoSchema.Person", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("DemoSchema.Person", "Discriminator");
            DropColumn("DemoSchema.Person", "Grade");
            RenameTable(name: "DemoSchema.Person", newName: "Teacher");
        }
    }
}
