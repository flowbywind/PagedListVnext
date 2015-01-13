using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Model;
using System;

namespace webpagedlist.Migrations
{
    public partial class person : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Age = c.String(),
                        Name = c.String()
                    })
                .PrimaryKey("PK_Person", t => t.ID);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Person");
        }
    }
}