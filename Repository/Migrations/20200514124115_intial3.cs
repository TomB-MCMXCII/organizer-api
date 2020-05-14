using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class intial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Days_DayId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_Days_DayId",
                table: "ScheduleEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoEntries_Days_DayId",
                table: "ToDoEntries");

            migrationBuilder.DropIndex(
                name: "IX_ToDoEntries_DayId",
                table: "ToDoEntries");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleEntries_DayId",
                table: "ScheduleEntries");

            migrationBuilder.DropIndex(
                name: "IX_Notes_DayId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Days",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "ToDoEntries");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "ScheduleEntries");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Days");

            migrationBuilder.AddColumn<DateTime>(
                name: "Daydate",
                table: "ToDoEntries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Daydate",
                table: "ScheduleEntries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Daydate",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Days",
                table: "Days",
                column: "date");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoEntries_Daydate",
                table: "ToDoEntries",
                column: "Daydate");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntries_Daydate",
                table: "ScheduleEntries",
                column: "Daydate");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Daydate",
                table: "Notes",
                column: "Daydate");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Days_Daydate",
                table: "Notes",
                column: "Daydate",
                principalTable: "Days",
                principalColumn: "date",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_Days_Daydate",
                table: "ScheduleEntries",
                column: "Daydate",
                principalTable: "Days",
                principalColumn: "date",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoEntries_Days_Daydate",
                table: "ToDoEntries",
                column: "Daydate",
                principalTable: "Days",
                principalColumn: "date",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Days_Daydate",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_Days_Daydate",
                table: "ScheduleEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoEntries_Days_Daydate",
                table: "ToDoEntries");

            migrationBuilder.DropIndex(
                name: "IX_ToDoEntries_Daydate",
                table: "ToDoEntries");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleEntries_Daydate",
                table: "ScheduleEntries");

            migrationBuilder.DropIndex(
                name: "IX_Notes_Daydate",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Days",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "Daydate",
                table: "ToDoEntries");

            migrationBuilder.DropColumn(
                name: "Daydate",
                table: "ScheduleEntries");

            migrationBuilder.DropColumn(
                name: "Daydate",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "ToDoEntries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "ScheduleEntries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Days",
                table: "Days",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoEntries_DayId",
                table: "ToDoEntries",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEntries_DayId",
                table: "ScheduleEntries",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_DayId",
                table: "Notes",
                column: "DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Days_DayId",
                table: "Notes",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_Days_DayId",
                table: "ScheduleEntries",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoEntries_Days_DayId",
                table: "ToDoEntries",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
