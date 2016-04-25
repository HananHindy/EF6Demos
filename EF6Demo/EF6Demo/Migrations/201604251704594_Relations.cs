namespace EF6Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "DemoSchema.StudentFile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "DemoSchema.Grade",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GradeName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("DemoSchema.Person", "USID", c => c.Int(nullable: false));
            AddColumn("DemoSchema.Person", "GradeID", c => c.Int());
            AddColumn("DemoSchema.Person", "FileID", c => c.Int());
            CreateIndex("DemoSchema.Person", "GradeID");
            CreateIndex("DemoSchema.Person", "FileID");
            AddForeignKey("DemoSchema.Person", "FileID", "DemoSchema.StudentFile", "ID", cascadeDelete: true);
            AddForeignKey("DemoSchema.Person", "GradeID", "DemoSchema.Grade", "ID");
            DropColumn("DemoSchema.Person", "Grade");
            AlterStoredProcedure(
                "DemoSchema.Person_Insert",
                p => new
                    {
                        USID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                    },
                body:
                    @"INSERT [DemoSchema].[Person]([USID], [FirstName], [LastName], [GradeID], [FileID], [Title], [Discriminator])
                      VALUES (@USID, @FirstName, @LastName, NULL, NULL, NULL, N'Person')
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [DemoSchema].[Person]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [DemoSchema].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
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
                      SET [USID] = @USID, [FirstName] = @FirstName, [LastName] = @LastName
                      WHERE ([ID] = @ID)"
            );
            
            AlterStoredProcedure(
                "DemoSchema.Student2_Insert",
                p => new
                    {
                        USID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                        GradeID = p.Int(),
                        FileID = p.Int(),
                    },
                body:
                    @"INSERT [DemoSchema].[Person]([USID], [FirstName], [LastName], [GradeID], [FileID], [Title], [Discriminator])
                      VALUES (@USID, @FirstName, @LastName, @GradeID, @FileID, NULL, N'Student2')
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [DemoSchema].[Person]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [DemoSchema].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            AlterStoredProcedure(
                "DemoSchema.Student2_Update",
                p => new
                    {
                        ID = p.Int(),
                        USID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                        GradeID = p.Int(),
                        FileID = p.Int(),
                    },
                body:
                    @"UPDATE [DemoSchema].[Person]
                      SET [USID] = @USID, [FirstName] = @FirstName, [LastName] = @LastName, [GradeID] = @GradeID, [FileID] = @FileID
                      WHERE ([ID] = @ID)"
            );
            
            AlterStoredProcedure(
                "DemoSchema.Teacher_Insert",
                p => new
                    {
                        USID = p.Int(),
                        FirstName = p.String(maxLength: 100),
                        LastName = p.String(maxLength: 100),
                        Title = p.String(maxLength: 100),
                    },
                body:
                    @"INSERT [DemoSchema].[Person]([USID], [FirstName], [LastName], [GradeID], [FileID], [Title], [Discriminator])
                      VALUES (@USID, @FirstName, @LastName, NULL, NULL, @Title, N'Teacher')
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [DemoSchema].[Person]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [DemoSchema].[Person] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
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
                      SET [USID] = @USID, [FirstName] = @FirstName, [LastName] = @LastName, [Title] = @Title
                      WHERE ([ID] = @ID)"
            );
            
        }
        
        public override void Down()
        {
            AddColumn("DemoSchema.Person", "Grade", c => c.Int());
            DropForeignKey("DemoSchema.Person", "GradeID", "DemoSchema.Grade");
            DropForeignKey("DemoSchema.Person", "FileID", "DemoSchema.StudentFile");
            DropIndex("DemoSchema.Person", new[] { "FileID" });
            DropIndex("DemoSchema.Person", new[] { "GradeID" });
            DropColumn("DemoSchema.Person", "FileID");
            DropColumn("DemoSchema.Person", "GradeID");
            DropColumn("DemoSchema.Person", "USID");
            DropTable("DemoSchema.Grade");
            DropTable("DemoSchema.StudentFile");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
