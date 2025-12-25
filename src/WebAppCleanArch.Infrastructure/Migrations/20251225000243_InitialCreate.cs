using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppCleanArch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Instructor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CourseName", "Description", "Instructor" },
                values: new object[,]
                {
                    { 1, "WEB101", "Web Programming", "Introduction to web development using HTML, CSS, and JavaScript", "Dr. John Smith" },
                    { 2, "MOB201", "Mobile Application Development", "Building mobile apps for Android and iOS", "Prof. Sarah Johnson" },
                    { 3, "DB301", "Database Management", "Database design and SQL programming", "Dr. Michael Brown" },
                    { 4, "SE401", "Software Engineering", "Principles and practices of software development", "Prof. Emily Davis" },
                    { 5, "DSA301", "Data Structures and Algorithms", "Advanced data structures and algorithm analysis", "Dr. Robert Wilson" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CourseId", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 9, "Jl. Raya No. 369, Palembang", null, "ivan.ibrahim@example.com", "Ivan Ibrahim", "081234567898" },
                    { 10, "Jl. Proklamasi No. 741, Denpasar", null, "jessica.jones@example.com", "Jessica Jones", "081234567899" },
                    { 1, "Jl. Merdeka No. 123, Jakarta", 1, "alice.anderson@example.com", "Alice Anderson", "081234567890" },
                    { 2, "Jl. Sudirman No. 456, Bandung", 1, "bob.baker@example.com", "Bob Baker", "081234567891" },
                    { 3, "Jl. Gatot Subroto No. 789, Surabaya", 2, "charlie.chen@example.com", "Charlie Chen", "081234567892" },
                    { 4, "Jl. Ahmad Yani No. 321, Yogyakarta", 2, "diana.davis@example.com", "Diana Davis", "081234567893" },
                    { 5, "Jl. Diponegoro No. 654, Semarang", 3, "edward.evans@example.com", "Edward Evans", "081234567894" },
                    { 6, "Jl. Pemuda No. 987, Malang", 3, "fiona.fisher@example.com", "Fiona Fisher", "081234567895" },
                    { 7, "Jl. Pahlawan No. 147, Medan", 4, "george.garcia@example.com", "George Garcia", "081234567896" },
                    { 8, "Jl. Veteran No. 258, Makassar", 5, "hannah.harris@example.com", "Hannah Harris", "081234567897" }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "Id", "AttendanceDate", "CourseId", "Notes", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), 1, null, "Present", 1 },
                    { 2, new DateTime(2025, 12, 21, 0, 0, 0, 0, DateTimeKind.Local), 1, null, "Present", 1 },
                    { 3, new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), 1, "Family emergency", "Absent", 1 },
                    { 4, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), 1, null, "Present", 2 },
                    { 5, new DateTime(2025, 12, 21, 0, 0, 0, 0, DateTimeKind.Local), 1, "Flu", "Sick", 2 },
                    { 6, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), 2, null, "Present", 3 },
                    { 7, new DateTime(2025, 12, 21, 0, 0, 0, 0, DateTimeKind.Local), 2, null, "Present", 3 },
                    { 8, new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), 2, null, "Present", 3 },
                    { 9, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), 2, "Doctor appointment", "Permission", 4 },
                    { 10, new DateTime(2025, 12, 21, 0, 0, 0, 0, DateTimeKind.Local), 2, null, "Present", 4 },
                    { 11, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), 3, null, "Present", 5 },
                    { 12, new DateTime(2025, 12, 21, 0, 0, 0, 0, DateTimeKind.Local), 3, null, "Present", 5 },
                    { 13, new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Local), 3, null, "Present", 5 },
                    { 14, new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Local), 3, "No reason provided", "Absent", 6 },
                    { 15, new DateTime(2025, 12, 21, 0, 0, 0, 0, DateTimeKind.Local), 3, null, "Present", 6 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrollmentDate", "Grade", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Active", 1 },
                    { 2, 3, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Active", 1 },
                    { 3, 1, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Active", 2 },
                    { 4, 2, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Active", 3 },
                    { 5, 5, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Active", 3 },
                    { 6, 2, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Active", 4 },
                    { 7, 3, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.5m, "Completed", 5 },
                    { 8, 3, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Active", 6 },
                    { 9, 1, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Active", 6 },
                    { 10, 4, new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Active", 7 },
                    { 11, 5, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Active", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_CourseId",
                table: "Attendances",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
