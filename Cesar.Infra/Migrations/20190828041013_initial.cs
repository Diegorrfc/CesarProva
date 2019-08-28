using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cesar.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collaborator",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 15, nullable: true, defaultValue: ""),
                    LastName = table.Column<string>(maxLength: 30, nullable: true, defaultValue: ""),
                    DocumentNumber = table.Column<string>(maxLength: 11, nullable: true, defaultValue: ""),
                    Email = table.Column<string>(maxLength: 500, nullable: true, defaultValue: ""),
                    PhoneNumber = table.Column<string>(maxLength: 12, nullable: true, defaultValue: ""),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    IdAddress = table.Column<Guid>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(maxLength: 12, nullable: true),
                    District = table.Column<string>(maxLength: 15, nullable: true),
                    City = table.Column<string>(maxLength: 15, nullable: true),
                    Country = table.Column<string>(maxLength: 15, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 11, nullable: true),
                    IdCollaborator = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Collaborator_IdCollaborator",
                        column: x => x.IdCollaborator,
                        principalTable: "Collaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_IdCollaborator",
                table: "Address",
                column: "IdCollaborator",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Collaborator");
        }
    }
}
