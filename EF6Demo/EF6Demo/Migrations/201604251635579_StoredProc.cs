namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoredProc : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "DemoSchema.Person_Insert",
                p => new
                    {
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                    },
                body:
                    @"INSERT [DemoSchema].[Person]([FirstName], [LastName], [Grade], [Title], [Discriminator])
                      VALUES (@FirstName, @LastName, NULL, NULL, N'Person')
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [DemoSchema].[Person]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [DemoSchema].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            CreateStoredProcedure(
                "DemoSchema.Person_Update",
                p => new
                    {
                        ID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                    },
                body:
                    @"UPDATE [DemoSchema].[Person]
                      SET [FirstName] = @FirstName, [LastName] = @LastName
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "DemoSchema.Person_Delete",
                p => new
                    {
                        ID = p.Int(),
                    },
                body:
                    @"DELETE [DemoSchema].[Person]
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "DemoSchema.Student2_Insert",
                p => new
                    {
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                        Grade = p.Int(),
                    },
                body:
                    @"INSERT [DemoSchema].[Person]([FirstName], [LastName], [Grade], [Title], [Discriminator])
                      VALUES (@FirstName, @LastName, @Grade, NULL, N'Student2')
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [DemoSchema].[Person]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [DemoSchema].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            CreateStoredProcedure(
                "DemoSchema.Student2_Update",
                p => new
                    {
                        ID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                        Grade = p.Int(),
                    },
                body:
                    @"UPDATE [DemoSchema].[Person]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [Grade] = @Grade
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "DemoSchema.Student2_Delete",
                p => new
                    {
                        ID = p.Int(),
                    },
                body:
                    @"DELETE [DemoSchema].[Person]
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "DemoSchema.Teacher_Insert",
                p => new
                    {
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                        Title = p.String(maxLength: 100),
                    },
                body:
                    @"INSERT [DemoSchema].[Person]([FirstName], [LastName], [Grade], [Title], [Discriminator])
                      VALUES (@FirstName, @LastName, NULL, @Title, N'Teacher')
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [DemoSchema].[Person]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [DemoSchema].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            CreateStoredProcedure(
                "DemoSchema.Teacher_Update",
                p => new
                    {
                        ID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                        Title = p.String(maxLength: 100),
                    },
                body:
                    @"UPDATE [DemoSchema].[Person]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [Title] = @Title
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "DemoSchema.Teacher_Delete",
                p => new
                    {
                        ID = p.Int(),
                    },
                body:
                    @"DELETE [DemoSchema].[Person]
                      WHERE ([ID] = @ID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("DemoSchema.Teacher_Delete");
            DropStoredProcedure("DemoSchema.Teacher_Update");
            DropStoredProcedure("DemoSchema.Teacher_Insert");
            DropStoredProcedure("DemoSchema.Student2_Delete");
            DropStoredProcedure("DemoSchema.Student2_Update");
            DropStoredProcedure("DemoSchema.Student2_Insert");
            DropStoredProcedure("DemoSchema.Person_Delete");
            DropStoredProcedure("DemoSchema.Person_Update");
            DropStoredProcedure("DemoSchema.Person_Insert");
        }
    }
}
