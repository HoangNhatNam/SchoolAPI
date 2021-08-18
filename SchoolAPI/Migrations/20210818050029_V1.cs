using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseID", "Credits", "Title" },
                values: new object[,]
                {
                    { 1, 2000000, "Thiet ke mau" },
                    { 2, 3000000, "Giao duc the chat" },
                    { 3, 4000000, "Quoc phong" },
                    { 4, 5000000, "Thiet ke web" },
                    { 5, 5000000, "Quan tri co so du lieu" }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "ID", "FirstMidName", "HireDate", "LastName" },
                values: new object[,]
                {
                    { 1, "Son Kim Quang", new DateTime(2021, 8, 18, 12, 0, 29, 350, DateTimeKind.Local).AddTicks(6067), "Thach" },
                    { 2, "Ngoc Tam", new DateTime(2021, 8, 18, 12, 0, 29, 350, DateTimeKind.Local).AddTicks(6792), "Vo" },
                    { 3, "Van A", new DateTime(2021, 8, 18, 12, 0, 29, 350, DateTimeKind.Local).AddTicks(6796), "Nguyen" },
                    { 4, "Thoai", new DateTime(2021, 8, 18, 12, 0, 29, 350, DateTimeKind.Local).AddTicks(6797), "Chi" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "ID", "EnrollmentDate", "FirstMidName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 18, 12, 0, 29, 348, DateTimeKind.Local).AddTicks(9116), "Nhat Nam", "Hoang" },
                    { 2, new DateTime(2021, 8, 18, 12, 0, 29, 349, DateTimeKind.Local).AddTicks(6801), "Nhat Minh", "Thi" },
                    { 3, new DateTime(2021, 8, 18, 12, 0, 29, 349, DateTimeKind.Local).AddTicks(6815), "Viet Hung", "Ngo" },
                    { 4, new DateTime(2021, 8, 18, 12, 0, 29, 349, DateTimeKind.Local).AddTicks(6817), "Duc Thai", "Luu" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "Enrollment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
