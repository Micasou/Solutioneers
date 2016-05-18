namespace Solutioneers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyUserInfoes",
                c => new
                    {
                        UID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UID);
            
            AlterColumn("dbo.AspNetUsers", "MyUserInfo_UID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "MyUserInfo_UID");
            AddForeignKey("dbo.AspNetUsers", "MyUserInfo_UID", "dbo.MyUserInfoes", "UID");
            DropColumn("dbo.AspNetUsers", "MyUserInfo_FirstName");
            DropColumn("dbo.AspNetUsers", "MyUserInfo_LastName");
            DropColumn("dbo.AspNetUsers", "MyUserInfo_BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MyUserInfo_BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "MyUserInfo_LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "MyUserInfo_FirstName", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "MyUserInfo_UID", "dbo.MyUserInfoes");
            DropIndex("dbo.AspNetUsers", new[] { "MyUserInfo_UID" });
            AlterColumn("dbo.AspNetUsers", "MyUserInfo_UID", c => c.Int(nullable: false));
            DropTable("dbo.MyUserInfoes");
        }
    }
}
