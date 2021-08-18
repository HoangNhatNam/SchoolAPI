using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssignment_Instructor_InstructorID",
                table: "OfficeAssignment");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Student",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "Student",
                newName: "first_mid_name");

            migrationBuilder.RenameColumn(
                name: "EnrollmentDate",
                table: "Student",
                newName: "enrollment_date");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Student",
                newName: "student_id");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "OfficeAssignment",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "OfficeAssignment",
                newName: "instructor_id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Instructor",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "HireDate",
                table: "Instructor",
                newName: "hire_date");

            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "Instructor",
                newName: "first_mid_name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Instructor",
                newName: "instructor_id");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "Enrollment",
                newName: "grade");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Enrollment",
                newName: "student_id");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Enrollment",
                newName: "course_id");

            migrationBuilder.RenameColumn(
                name: "EnrollmentID",
                table: "Enrollment",
                newName: "enrollment_id");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                newName: "IX_Enrollment_student_id");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                newName: "IX_Enrollment_course_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Course",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Credits",
                table: "Course",
                newName: "credits");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Course",
                newName: "course_id");

            migrationBuilder.AlterColumn<int>(
                name: "course_id",
                table: "Course",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "department_id",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseAssignment",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false),
                    instructor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignment", x => new { x.course_id, x.instructor_id });
                    table.ForeignKey(
                        name: "FK_CourseAssignment_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssignment_Instructor_instructor_id",
                        column: x => x.instructor_id,
                        principalTable: "Instructor",
                        principalColumn: "instructor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    instructor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.department_id);
                    table.ForeignKey(
                        name: "FK_Department_Instructor_instructor_id",
                        column: x => x.instructor_id,
                        principalTable: "Instructor",
                        principalColumn: "instructor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseAssignment",
                columns: new[] { "course_id", "instructor_id" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 5, 1 },
                    { 3, 2 },
                    { 2, 3 },
                    { 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "department_id", "budget", "instructor_id", "name", "start_date" },
                values: new object[,]
                {
                    { 7, 3000000m, 1, "IT", new DateTime(2021, 8, 18, 12, 15, 50, 279, DateTimeKind.Local).AddTicks(6309) },
                    { 6, 3000000m, 3, "Mathematics", new DateTime(2021, 8, 18, 12, 15, 50, 279, DateTimeKind.Local).AddTicks(6308) },
                    { 4, 3000000m, 1, "Social Studies", new DateTime(2021, 8, 18, 12, 15, 50, 279, DateTimeKind.Local).AddTicks(6305) },
                    { 5, 3000000m, 2, "Theology", new DateTime(2021, 8, 18, 12, 15, 50, 279, DateTimeKind.Local).AddTicks(6307) },
                    { 2, 3000000m, 2, "Computer Science", new DateTime(2021, 8, 18, 12, 15, 50, 279, DateTimeKind.Local).AddTicks(6298) },
                    { 1, 3000000m, 1, "English", new DateTime(2021, 8, 18, 12, 15, 50, 279, DateTimeKind.Local).AddTicks(5280) },
                    { 3, 3000000m, 3, "Scince", new DateTime(2021, 8, 18, 12, 15, 50, 279, DateTimeKind.Local).AddTicks(6304) }
                });

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 1,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 12, 15, 50, 279, DateTimeKind.Local).AddTicks(3340));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 2,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 12, 15, 50, 279, DateTimeKind.Local).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 3,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 12, 15, 50, 279, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "instructor_id",
                keyValue: 4,
                column: "hire_date",
                value: new DateTime(2021, 8, 18, 12, 15, 50, 279, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 1,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 12, 15, 50, 277, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 2,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 12, 15, 50, 278, DateTimeKind.Local).AddTicks(640));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 3,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 12, 15, 50, 278, DateTimeKind.Local).AddTicks(658));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "student_id",
                keyValue: 4,
                column: "enrollment_date",
                value: new DateTime(2021, 8, 18, 12, 15, 50, 278, DateTimeKind.Local).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "course_id",
                keyValue: 1,
                column: "department_id",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "course_id",
                keyValue: 2,
                column: "department_id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "course_id",
                keyValue: 3,
                column: "department_id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "course_id",
                keyValue: 4,
                column: "department_id",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "course_id",
                keyValue: 5,
                column: "department_id",
                value: 7);

            migrationBuilder.CreateIndex(
                name: "IX_Course_department_id",
                table: "Course",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignment_instructor_id",
                table: "CourseAssignment",
                column: "instructor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_instructor_id",
                table: "Department",
                column: "instructor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department_department_id",
                table: "Course",
                column: "department_id",
                principalTable: "Department",
                principalColumn: "department_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_course_id",
                table: "Enrollment",
                column: "course_id",
                principalTable: "Course",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_student_id",
                table: "Enrollment",
                column: "student_id",
                principalTable: "Student",
                principalColumn: "student_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignment_Instructor_instructor_id",
                table: "OfficeAssignment",
                column: "instructor_id",
                principalTable: "Instructor",
                principalColumn: "instructor_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department_department_id",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_course_id",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_student_id",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssignment_Instructor_instructor_id",
                table: "OfficeAssignment");

            migrationBuilder.DropTable(
                name: "CourseAssignment");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Course_department_id",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "department_id",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Student",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_mid_name",
                table: "Student",
                newName: "FirstMidName");

            migrationBuilder.RenameColumn(
                name: "enrollment_date",
                table: "Student",
                newName: "EnrollmentDate");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "Student",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "OfficeAssignment",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "instructor_id",
                table: "OfficeAssignment",
                newName: "InstructorID");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Instructor",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "hire_date",
                table: "Instructor",
                newName: "HireDate");

            migrationBuilder.RenameColumn(
                name: "first_mid_name",
                table: "Instructor",
                newName: "FirstMidName");

            migrationBuilder.RenameColumn(
                name: "instructor_id",
                table: "Instructor",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "grade",
                table: "Enrollment",
                newName: "Grade");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "Enrollment",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Enrollment",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "enrollment_id",
                table: "Enrollment",
                newName: "EnrollmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_student_id",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_course_id",
                table: "Enrollment",
                newName: "IX_Enrollment_CourseID");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Course",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "credits",
                table: "Course",
                newName: "Credits");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Course",
                newName: "CourseID");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Course",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2021, 8, 18, 12, 0, 29, 350, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2021, 8, 18, 12, 0, 29, 350, DateTimeKind.Local).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2021, 8, 18, 12, 0, 29, 350, DateTimeKind.Local).AddTicks(6796));

            migrationBuilder.UpdateData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 4,
                column: "HireDate",
                value: new DateTime(2021, 8, 18, 12, 0, 29, 350, DateTimeKind.Local).AddTicks(6797));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "ID",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2021, 8, 18, 12, 0, 29, 348, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "ID",
                keyValue: 2,
                column: "EnrollmentDate",
                value: new DateTime(2021, 8, 18, 12, 0, 29, 349, DateTimeKind.Local).AddTicks(6801));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "ID",
                keyValue: 3,
                column: "EnrollmentDate",
                value: new DateTime(2021, 8, 18, 12, 0, 29, 349, DateTimeKind.Local).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "ID",
                keyValue: 4,
                column: "EnrollmentDate",
                value: new DateTime(2021, 8, 18, 12, 0, 29, 349, DateTimeKind.Local).AddTicks(6817));

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                table: "Enrollment",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssignment_Instructor_InstructorID",
                table: "OfficeAssignment",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
