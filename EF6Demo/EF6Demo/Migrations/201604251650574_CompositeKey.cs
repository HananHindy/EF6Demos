namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompositeKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("DemoSchema.Person");
            AddColumn("DemoSchema.Person", "USID", c => c.Int(nullable: false));
            AlterColumn("DemoSchema.Person", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("DemoSchema.Person", new[] { "ID", "USID" });
            AlterStoredProcedure(
                "DemoSchema.Person_Insert",
                p => new
                    {
                        ID = p.Int(),
                        USID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                    },
                body:
                    @"INSERT [DemoSchema].[Person]([ID], [USID], [FirstName], [LastName], [Grade], [Title], [Discriminator])
                      VALUES (@ID, @USID, @FirstName, @LastName, NULL, NULL, N'Person')"
            );
            
            AlterStoredProcedure(
                "DemoSchema.Person_Update",
                p => new
                    {
                        ID = p.Int(),
                        USID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                    },
                body:
                    @"UPDATE [DemoSchema].[Person]
                      SET [FirstName] = @FirstName, [LastName] = @LastName
                      WHERE (([ID] = @ID) AND ([USID] = @USID))"
            );
            
            AlterStoredProcedure(
                "DemoSchema.Person_Delete",
                p => new
                    {
                        ID = p.Int(),
                        USID = p.Int(),
                    },
                body:
                    @"DELETE [DemoSchema].[Person]
                      WHERE (([ID] = @ID) AND ([USID] = @USID))"
            );
            
            AlterStoredProcedure(
                "DemoSchema.Student2_Insert",
                p => new
                    {
                        ID = p.Int(),
                        USID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                        Grade = p.Int(),
                    },
                body:
                    @"INSERT [DemoSchema].[Person]([ID], [USID], [FirstName], [LastName], [Grade], [Title], [Discriminator])
                      VALUES (@ID, @USID, @FirstName, @LastName, @Grade, NULL, N'Student2')"
            );
            
            AlterStoredProcedure(
                "DemoSchema.Student2_Update",
                p => new
                    {
                        ID = p.Int(),
                        USID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                        Grade = p.Int(),
                    },
                body:
                    @"UPDATE [DemoSchema].[Person]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [Grade] = @Grade
                      WHERE (([ID] = @ID) AND ([USID] = @USID))"
            );
            
            AlterStoredProcedure(
                "DemoSchema.Student2_Delete",
                p => new
                    {
                        ID = p.Int(),
                        USID = p.Int(),
                    },
                body:
                    @"DELETE [DemoSchema].[Person]
                      WHERE (([ID] = @ID) AND ([USID] = @USID))"
            );
            
            AlterStoredProcedure(
                "DemoSchema.Teacher_Insert",
                p => new
                    {
                        ID = p.Int(),
                        USID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                        Title = p.String(maxLength: 100),
                    },
                body:
                    @"INSERT [DemoSchema].[Person]([ID], [USID], [FirstName], [LastName], [Grade], [Title], [Discriminator])
                      VALUES (@ID, @USID, @FirstName, @LastName, NULL, @Title, N'Teacher')"
            );
            
            AlterStoredProcedure(
                "DemoSchema.Teacher_Update",
                p => new
                    {
                        ID = p.Int(),
                        USID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                        Title = p.String(maxLength: 100),
                    },
                body:
                    @"UPDATE [DemoSchema].[Person]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [Title] = @Title
                      WHERE (([ID] = @ID) AND ([USID] = @USID))"
            );
            
            AlterStoredProcedure(
                "DemoSchema.Teacher_Delete",
                p => new
                    {
                        ID = p.Int(),
                        USID = p.Int(),
                    },
                body:
                    @"DELETE [DemoSchema].[Person]
                      WHERE (([ID] = @ID) AND ([USID] = @USID))"
            );
            
        }
        
        public override void Down()
        {
            DropPrimaryKey("DemoSchema.Person");
            AlterColumn("DemoSchema.Person", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("DemoSchema.Person", "USID");
            AddPrimaryKey("DemoSchema.Person", "ID");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
