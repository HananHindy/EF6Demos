namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Class", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Student", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Student", "LastName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "LastName", c => c.String());
            AlterColumn("dbo.Student", "FirstName", c => c.String());
            AlterColumn("dbo.Class", "Title", c => c.String());
        }
    }
}
