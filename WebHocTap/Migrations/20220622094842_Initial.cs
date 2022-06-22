using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebHocTap.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    gradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gradeName = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.gradeId);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    positionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    positionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.positionId);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    subjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.subjectId);
                });

            migrationBuilder.CreateTable(
                name: "TestCategory",
                columns: table => new
                {
                    testCateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    testCateName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCategory", x => x.testCateId);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    classId = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.classId);
                    table.ForeignKey(
                        name: "FK_Class_Grade_Grade",
                        column: x => x.Grade,
                        principalTable: "Grade",
                        principalColumn: "gradeId");
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    teacherId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    birthDay = table.Column<DateTime>(type: "date", nullable: true),
                    gender = table.Column<bool>(type: "bit", nullable: true),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.teacherId);
                    table.ForeignKey(
                        name: "FK_Admin_Position_Position",
                        column: x => x.Position,
                        principalTable: "Position",
                        principalColumn: "positionId");
                    table.ForeignKey(
                        name: "FK_Admin_Subject_Subject",
                        column: x => x.Subject,
                        principalTable: "Subject",
                        principalColumn: "subjectId");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startDate = table.Column<DateTime>(type: "date", nullable: true),
                    endDate = table.Column<DateTime>(type: "date", nullable: true),
                    linkOnline = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Subject = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.courseId);
                    table.ForeignKey(
                        name: "FK_Course_Subject_Subject",
                        column: x => x.Subject,
                        principalTable: "Subject",
                        principalColumn: "subjectId");
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    docId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    docPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Subject = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.docId);
                    table.ForeignKey(
                        name: "FK_Document_Subject_Subject",
                        column: x => x.Subject,
                        principalTable: "Subject",
                        principalColumn: "subjectId");
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    testId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TestCategory = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.testId);
                    table.ForeignKey(
                        name: "FK_Test_TestCategory_TestCategory",
                        column: x => x.TestCategory,
                        principalTable: "TestCategory",
                        principalColumn: "testCateId");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: true),
                    birthDay = table.Column<DateTime>(type: "date", nullable: true),
                    Class = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.studentId);
                    table.ForeignKey(
                        name: "FK_Student_Class_Class",
                        column: x => x.Class,
                        principalTable: "Class",
                        principalColumn: "classId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminAccount",
                columns: table => new
                {
                    userName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    passWord = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    isLogin = table.Column<bool>(type: "bit", nullable: true),
                    Admin = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAccount", x => x.userName);
                    table.ForeignKey(
                        name: "FK_AdminAccount_Admin_Admin",
                        column: x => x.Admin,
                        principalTable: "Admin",
                        principalColumn: "teacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class_Course",
                columns: table => new
                {
                    lassCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lession = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Class = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Course = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class_Course", x => x.lassCourseId);
                    table.ForeignKey(
                        name: "FK_Class_Course_Class_Class",
                        column: x => x.Class,
                        principalTable: "Class",
                        principalColumn: "classId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_Course_Course_Course",
                        column: x => x.Course,
                        principalTable: "Course",
                        principalColumn: "courseId");
                });

            migrationBuilder.CreateTable(
                name: "Class_Test",
                columns: table => new
                {
                    classTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isComplete = table.Column<int>(type: "int", nullable: true),
                    testDate = table.Column<DateTime>(type: "date", nullable: true),
                    testDuration = table.Column<int>(type: "int", nullable: true),
                    Class = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Test = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class_Test", x => x.classTestId);
                    table.ForeignKey(
                        name: "FK_Class_Test_Class_Class",
                        column: x => x.Class,
                        principalTable: "Class",
                        principalColumn: "classId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_Test_Test_Test",
                        column: x => x.Test,
                        principalTable: "Test",
                        principalColumn: "testId");
                });

            migrationBuilder.CreateTable(
                name: "StudentAccount",
                columns: table => new
                {
                    userName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    passWord = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    isLogin = table.Column<bool>(type: "bit", nullable: true),
                    Student = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAccount", x => x.userName);
                    table.ForeignKey(
                        name: "FK_StudentAccount_Student_Student",
                        column: x => x.Student,
                        principalTable: "Student",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student_Test",
                columns: table => new
                {
                    studentTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    documentTest = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    testMath = table.Column<double>(type: "float", nullable: true),
                    Student = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Class_Test = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Test", x => x.studentTestId);
                    table.ForeignKey(
                        name: "FK_Student_Test_Class_Test_Class_Test",
                        column: x => x.Class_Test,
                        principalTable: "Class_Test",
                        principalColumn: "classTestId");
                    table.ForeignKey(
                        name: "FK_Student_Test_Student_Student",
                        column: x => x.Student,
                        principalTable: "Student",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningOutcomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: true),
                    Student_Test = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningOutcomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningOutcomes_Student_Student",
                        column: x => x.Student,
                        principalTable: "Student",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningOutcomes_Student_Test_Student_Test",
                        column: x => x.Student_Test,
                        principalTable: "Student_Test",
                        principalColumn: "studentTestId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Position",
                table: "Admin",
                column: "Position");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Subject",
                table: "Admin",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_AdminAccount_Admin",
                table: "AdminAccount",
                column: "Admin");

            migrationBuilder.CreateIndex(
                name: "IX_Class_Grade",
                table: "Class",
                column: "Grade");

            migrationBuilder.CreateIndex(
                name: "IX_Class_Course_Class",
                table: "Class_Course",
                column: "Class");

            migrationBuilder.CreateIndex(
                name: "IX_Class_Course_Course",
                table: "Class_Course",
                column: "Course");

            migrationBuilder.CreateIndex(
                name: "IX_Class_Test_Class",
                table: "Class_Test",
                column: "Class");

            migrationBuilder.CreateIndex(
                name: "IX_Class_Test_Test",
                table: "Class_Test",
                column: "Test");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Subject",
                table: "Course",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_Document_Subject",
                table: "Document",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomes_Student",
                table: "LearningOutcomes",
                column: "Student");

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomes_Student_Test",
                table: "LearningOutcomes",
                column: "Student_Test");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Class",
                table: "Student",
                column: "Class");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Test_Class_Test",
                table: "Student_Test",
                column: "Class_Test");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Test_Student",
                table: "Student_Test",
                column: "Student");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAccount_Student",
                table: "StudentAccount",
                column: "Student");

            migrationBuilder.CreateIndex(
                name: "IX_Test_TestCategory",
                table: "Test",
                column: "TestCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminAccount");

            migrationBuilder.DropTable(
                name: "Class_Course");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "LearningOutcomes");

            migrationBuilder.DropTable(
                name: "StudentAccount");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student_Test");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Class_Test");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "TestCategory");

            migrationBuilder.DropTable(
                name: "Grade");
        }
    }
}
