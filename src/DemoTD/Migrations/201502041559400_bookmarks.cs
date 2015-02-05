using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Model;
using System;

namespace DemoTD.Migrations
{
    public partial class bookmarks : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Bookmark",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Accept = c.String(),
                        Description = c.String(),
                        NoOfVisits = c.Int(nullable: false),
                        Title = c.String(),
                        Url = c.String()
                    })
                .PrimaryKey("PK_Bookmark", t => t.Id);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Bookmark");
        }
    }
}