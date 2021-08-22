using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    instructor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    first_mid_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    hire_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.instructor_id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    first_mid_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enrollment_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    budget = table.Column<decimal>(type: "decimal", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "OfficeAssignment",
                columns: table => new
                {
                    instructor_id = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignment", x => x.instructor_id);
                    table.ForeignKey(
                        name: "FK_OfficeAssignment_Instructor_instructor_id",
                        column: x => x.instructor_id,
                        principalTable: "Instructor",
                        principalColumn: "instructor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    credits = table.Column<int>(type: "int", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.course_id);
                    table.ForeignKey(
                        name: "FK_Course_Department_department_id",
                        column: x => x.department_id,
                        principalTable: "Department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseAssignment_Instructor_instructor_id",
                        column: x => x.instructor_id,
                        principalTable: "Instructor",
                        principalColumn: "instructor_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    enrollment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.enrollment_id);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_student_id",
                        column: x => x.student_id,
                        principalTable: "Student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "instructor_id", "first_mid_name", "hire_date", "last_name" },
                values: new object[,]
                {
                    { 1, "Son Kim Quang", new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(2418), "Thach" },
                    { 2, "Ngoc Tam", new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(3058), "Vo" },
                    { 3, "Van A", new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(3063), "Nguyen" },
                    { 4, "Thoai", new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(3065), "Chi" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "student_id", "enrollment_date", "first_mid_name", "last_name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 22, 11, 2, 40, 212, DateTimeKind.Local).AddTicks(7200), "Nhat Nam", "Hoang" },
                    { 2, new DateTime(2021, 8, 22, 11, 2, 40, 214, DateTimeKind.Local).AddTicks(2408), "Nhat Minh", "Thi" },
                    { 3, new DateTime(2021, 8, 22, 11, 2, 40, 214, DateTimeKind.Local).AddTicks(2421), "Viet Hung", "Ngo" },
                    { 4, new DateTime(2021, 8, 22, 11, 2, 40, 214, DateTimeKind.Local).AddTicks(2423), "Duc Thai", "Luu" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "department_id", "budget", "instructor_id", "name", "start_date" },
                values: new object[,]
                {
                    { 1, 3000000m, 1, "English", new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(3796) },
                    { 4, 3000000m, 1, "Social Studies", new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4531) },
                    { 7, 3000000m, 1, "IT", new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4535) },
                    { 2, 3000000m, 2, "Computer Science", new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4526) },
                    { 5, 3000000m, 2, "Theology", new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4532) },
                    { 3, 3000000m, 3, "Scince", new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4530) },
                    { 6, 3000000m, 3, "Mathematics", new DateTime(2021, 8, 22, 11, 2, 40, 215, DateTimeKind.Local).AddTicks(4534) }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "course_id", "credits", "department_id", "title" },
                values: new object[,]
                {
                    { 1, 2000000, 7, "Thiet ke mau" },
                    { 4, 5000000, 7, "Thiet ke web" },
                    { 5, 5000000, 7, "Quan tri co so du lieu" },
                    { 2, 3000000, 2, "Giao duc the chat" },
                    { 3, 4000000, 3, "Quoc phong" }
                });

            migrationBuilder.InsertData(
                table: "CourseAssignment",
                columns: new[] { "course_id", "instructor_id" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 4, 1 },
                    { 5, 1 },
                    { 2, 3 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "enrollment_id", "course_id", "grade", "student_id" },
                values: new object[,]
                {
                    { 5, 1, "B", 3 },
                    { 3, 4, "D", 2 },
                    { 7, 4, "E", 3 },
                    { 4, 5, "A", 2 },
                    { 1, 2, "A", 1 },
                    { 6, 2, "None", 3 },
                    { 2, 3, "C", 1 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_course_id",
                table: "Enrollment",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_student_id",
                table: "Enrollment",
                column: "student_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssignment");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "OfficeAssignment");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Instructor");
        }
    }
}
