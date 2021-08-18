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
                value: new DateTime(2021, 8, 18, 18, 2, 54, 635, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 2,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 635, DateTimeKind.Local).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 3,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 635, DateTimeKind.Local).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 4,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 635, DateTimeKind.Local).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 5,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 635, DateTimeKind.Local).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 6,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 635, DateTimeKind.Local).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 7,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 635, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 1,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 635, DateTimeKind.Local).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 2,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 635, DateTimeKind.Local).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 3,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 635, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 4,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 635, DateTimeKind.Local).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 1,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 632, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 2,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 633, DateTimeKind.Local).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 3,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 633, DateTimeKind.Local).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 4,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 18, 2, 54, 633, DateTimeKind.Local).AddTicks(8571));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 1,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 227, DateTimeKind.Local).AddTicks(3187));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 2,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 227, DateTimeKind.Local).AddTicks(3873));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 3,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 227, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 4,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 227, DateTimeKind.Local).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 5,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 227, DateTimeKind.Local).AddTicks(3879));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 6,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 227, DateTimeKind.Local).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "department_id",
                keyValue: 7,
                column: "start_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 227, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 1,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 227, DateTimeKind.Local).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 2,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 227, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 3,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 227, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 4,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 227, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 1,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 225, DateTimeKind.Local).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 2,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 226, DateTimeKind.Local).AddTicks(2212));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 3,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 226, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 4,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 15, 10, 9, 226, DateTimeKind.Local).AddTicks(2228));
        }
    }
}
