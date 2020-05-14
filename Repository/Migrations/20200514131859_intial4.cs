using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class intial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoEntries_Days_Daydate",
                table: "ToDoEntries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Daydate",
                table: "ToDoEntries",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoEntries_Days_Daydate",
                table: "ToDoEntries",
                column: "Daydate",
                principalTable: "Days",
                principalColumn: "date",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoEntries_Days_Daydate",
                table: "ToDoEntries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Daydate",
                table: "ToDoEntries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoEntries_Days_Daydate",
                table: "ToDoEntries",
                column: "Daydate",
                principalTable: "Days",
                principalColumn: "date",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
