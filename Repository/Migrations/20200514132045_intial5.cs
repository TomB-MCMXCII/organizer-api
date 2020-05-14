using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class intial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Days_Daydate",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_Days_Daydate",
                table: "ScheduleEntries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Daydate",
                table: "ScheduleEntries",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Daydate",
                table: "Notes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Days_Daydate",
                table: "Notes",
                column: "Daydate",
                principalTable: "Days",
                principalColumn: "date",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntries_Days_Daydate",
                table: "ScheduleEntries",
                column: "Daydate",
                principalTable: "Days",
                principalColumn: "date",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Days_Daydate",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntries_Days_Daydate",
                table: "ScheduleEntries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Daydate",
                table: "ScheduleEntries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Daydate",
                table: "Notes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

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
        }
    }
}
