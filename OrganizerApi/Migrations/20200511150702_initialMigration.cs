using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizerApi.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    date = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.date);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    Daydate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Days_Daydate",
                        column: x => x.Daydate,
                        principalTable: "Days",
                        principalColumn: "date",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startTime = table.Column<DateTime>(nullable: false),
                    endTime = table.Column<DateTime>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    Daydate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleEntries_Days_Daydate",
                        column: x => x.Daydate,
                        principalTable: "Days",
                        principalColumn: "date",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToDoEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    Daydate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoEntries_Days_Daydate",
                        column: x => x.Daydate,
                        principalTable: "Days",
                        principalColumn: "date",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Daydate",
                table: "Notes",
                column: "Daydate");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntries_Daydate",
                table: "ScheduleEntries",
                column: "Daydate");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoEntries_Daydate",
                table: "ToDoEntries",
                column: "Daydate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "ScheduleEntries");

            migrationBuilder.DropTable(
                name: "ToDoEntries");

            migrationBuilder.DropTable(
                name: "Days");
        }
    }
}
