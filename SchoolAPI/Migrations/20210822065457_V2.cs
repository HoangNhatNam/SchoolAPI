using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 1,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 719, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 2,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 719, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 3,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 719, DateTimeKind.Local).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 4,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 719, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 5,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 719, DateTimeKind.Local).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 6,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 719, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 7,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 719, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 1,
                column: "hire_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 719, DateTimeKind.Local).AddTicks(299));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 2,
                column: "hire_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 719, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 3,
                column: "hire_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 719, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 4,
                column: "hire_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 719, DateTimeKind.Local).AddTicks(1214));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 1,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 715, DateTimeKind.Local).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 2,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 717, DateTimeKind.Local).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 3,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 717, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 4,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 22, 13, 54, 56, 717, DateTimeKind.Local).AddTicks(2568));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 1,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 2,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 3,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 4,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 5,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 6,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 7,
                column: "start_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 1,
                column: "hire_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 2,
                column: "hire_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 3,
                column: "hire_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 4,
                column: "hire_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 1,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 212, DateTimeKind.Local).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 2,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 214, DateTimeKind.Local).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 3,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 214, DateTimeKind.Local).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 4,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 22, 11, 2, 40, 214, DateTimeKind.Local).AddTicks(2423));
        }
    }
}
