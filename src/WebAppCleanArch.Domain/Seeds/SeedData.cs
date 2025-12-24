using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Domain.Seeds
{
    public static class SeedData
    {
        // Seed Courses
        public static List<Course> GetCourses()
        {
            return new List<Course>
            {
                new Course
                {
                    Id = 1,
                    CourseName = "Web Programming",
                    CourseCode = "WEB101",
                    Description = "Introduction to web development using HTML, CSS, and JavaScript",
                    Instructor = "Dr. John Smith"
                },
                new Course
                {
                    Id = 2,
                    CourseName = "Mobile Application Development",
                    CourseCode = "MOB201",
                    Description = "Building mobile apps for Android and iOS",
                    Instructor = "Prof. Sarah Johnson"
                },
                new Course
                {
                    Id = 3,
                    CourseName = "Database Management",
                    CourseCode = "DB301",
                    Description = "Database design and SQL programming",
                    Instructor = "Dr. Michael Brown"
                },
                new Course
                {
                    Id = 4,
                    CourseName = "Software Engineering",
                    CourseCode = "SE401",
                    Description = "Principles and practices of software development",
                    Instructor = "Prof. Emily Davis"
                },
                new Course
                {
                    Id = 5,
                    CourseName = "Data Structures and Algorithms",
                    CourseCode = "DSA301",
                    Description = "Advanced data structures and algorithm analysis",
                    Instructor = "Dr. Robert Wilson"
                }
            };
        }

        // Seed Students
        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Alice Anderson",
                    Email = "alice.anderson@example.com",
                    PhoneNumber = "081234567890",
                    Address = "Jl. Merdeka No. 123, Jakarta",
                    CourseId = 1
                },
                new Student
                {
                    Id = 2,
                    Name = "Bob Baker",
                    Email = "bob.baker@example.com",
                    PhoneNumber = "081234567891",
                    Address = "Jl. Sudirman No. 456, Bandung",
                    CourseId = 1
                },
                new Student
                {
                    Id = 3,
                    Name = "Charlie Chen",
                    Email = "charlie.chen@example.com",
                    PhoneNumber = "081234567892",
                    Address = "Jl. Gatot Subroto No. 789, Surabaya",
                    CourseId = 2
                },
                new Student
                {
                    Id = 4,
                    Name = "Diana Davis",
                    Email = "diana.davis@example.com",
                    PhoneNumber = "081234567893",
                    Address = "Jl. Ahmad Yani No. 321, Yogyakarta",
                    CourseId = 2
                },
                new Student
                {
                    Id = 5,
                    Name = "Edward Evans",
                    Email = "edward.evans@example.com",
                    PhoneNumber = "081234567894",
                    Address = "Jl. Diponegoro No. 654, Semarang",
                    CourseId = 3
                },
                new Student
                {
                    Id = 6,
                    Name = "Fiona Fisher",
                    Email = "fiona.fisher@example.com",
                    PhoneNumber = "081234567895",
                    Address = "Jl. Pemuda No. 987, Malang",
                    CourseId = 3
                },
                new Student
                {
                    Id = 7,
                    Name = "George Garcia",
                    Email = "george.garcia@example.com",
                    PhoneNumber = "081234567896",
                    Address = "Jl. Pahlawan No. 147, Medan",
                    CourseId = 4
                },
                new Student
                {
                    Id = 8,
                    Name = "Hannah Harris",
                    Email = "hannah.harris@example.com",
                    PhoneNumber = "081234567897",
                    Address = "Jl. Veteran No. 258, Makassar",
                    CourseId = 5
                },
                new Student
                {
                    Id = 9,
                    Name = "Ivan Ibrahim",
                    Email = "ivan.ibrahim@example.com",
                    PhoneNumber = "081234567898",
                    Address = "Jl. Raya No. 369, Palembang",
                    CourseId = null // Student tanpa course
                },
                new Student
                {
                    Id = 10,
                    Name = "Jessica Jones",
                    Email = "jessica.jones@example.com",
                    PhoneNumber = "081234567899",
                    Address = "Jl. Proklamasi No. 741, Denpasar",
                    CourseId = null // Student tanpa course
                }
            };
        }

        // Seed Enrollments
        public static List<Enrollment> GetEnrollments()
        {
            return new List<Enrollment>
            {
                // Alice enrolled in multiple courses
                new Enrollment
                {
                    Id = 1,
                    StudentId = 1,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2024, 9, 1),
                    Status = "Active",
                    Grade = null
                },
                new Enrollment
                {
                    Id = 2,
                    StudentId = 1,
                    CourseId = 3,
                    EnrollmentDate = new DateTime(2024, 9, 5),
                    Status = "Active",
                    Grade = null
                },
                // Bob enrolled in Web Programming
                new Enrollment
                {
                    Id = 3,
                    StudentId = 2,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2024, 9, 1),
                    Status = "Active",
                    Grade = null
                },
                // Charlie enrolled in Mobile Dev and DSA
                new Enrollment
                {
                    Id = 4,
                    StudentId = 3,
                    CourseId = 2,
                    EnrollmentDate = new DateTime(2024, 9, 2),
                    Status = "Active",
                    Grade = null
                },
                new Enrollment
                {
                    Id = 5,
                    StudentId = 3,
                    CourseId = 5,
                    EnrollmentDate = new DateTime(2024, 9, 10),
                    Status = "Active",
                    Grade = null
                },
                // Diana enrolled in Mobile Dev
                new Enrollment
                {
                    Id = 6,
                    StudentId = 4,
                    CourseId = 2,
                    EnrollmentDate = new DateTime(2024, 9, 2),
                    Status = "Active",
                    Grade = null
                },
                // Edward enrolled in Database
                new Enrollment
                {
                    Id = 7,
                    StudentId = 5,
                    CourseId = 3,
                    EnrollmentDate = new DateTime(2024, 9, 3),
                    Status = "Completed",
                    Grade = 95.5m // Changed to decimal
                },
                // Fiona enrolled in Database and Web Programming
                new Enrollment
                {
                    Id = 8,
                    StudentId = 6,
                    CourseId = 3,
                    EnrollmentDate = new DateTime(2024, 9, 3),
                    Status = "Active",
                    Grade = null
                },
                new Enrollment
                {
                    Id = 9,
                    StudentId = 6,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2024, 9, 15),
                    Status = "Active",
                    Grade = null
                },
                // George enrolled in Software Engineering
                new Enrollment
                {
                    Id = 10,
                    StudentId = 7,
                    CourseId = 4,
                    EnrollmentDate = new DateTime(2024, 9, 4),
                    Status = "Active",
                    Grade = null
                },
                // Hannah enrolled in DSA
                new Enrollment
                {
                    Id = 11,
                    StudentId = 8,
                    CourseId = 5,
                    EnrollmentDate = new DateTime(2024, 9, 5),
                    Status = "Active",
                    Grade = null
                }
            };
        }

        // Seed Attendances
        public static List<Attendance> GetAttendances()
        {
            var today = DateTime.Today;
            return new List<Attendance>
            {
                // Alice's attendances for Web Programming
                new Attendance
                {
                    Id = 1,
                    StudentId = 1,
                    CourseId = 1,
                    AttendanceDate = today.AddDays(-5),
                    Status = "Present",
                    Notes = null
                },
                new Attendance
                {
                    Id = 2,
                    StudentId = 1,
                    CourseId = 1,
                    AttendanceDate = today.AddDays(-4),
                    Status = "Present",
                    Notes = null
                },
                new Attendance
                {
                    Id = 3,
                    StudentId = 1,
                    CourseId = 1,
                    AttendanceDate = today.AddDays(-3),
                    Status = "Absent",
                    Notes = "Family emergency"
                },
                // Bob's attendances for Web Programming
                new Attendance
                {
                    Id = 4,
                    StudentId = 2,
                    CourseId = 1,
                    AttendanceDate = today.AddDays(-5),
                    Status = "Present",
                    Notes = null
                },
                new Attendance
                {
                    Id = 5,
                    StudentId = 2,
                    CourseId = 1,
                    AttendanceDate = today.AddDays(-4),
                    Status = "Sick",
                    Notes = "Flu"
                },
                // Charlie's attendances for Mobile Dev
                new Attendance
                {
                    Id = 6,
                    StudentId = 3,
                    CourseId = 2,
                    AttendanceDate = today.AddDays(-5),
                    Status = "Present",
                    Notes = null
                },
                new Attendance
                {
                    Id = 7,
                    StudentId = 3,
                    CourseId = 2,
                    AttendanceDate = today.AddDays(-4),
                    Status = "Present",
                    Notes = null
                },
                new Attendance
                {
                    Id = 8,
                    StudentId = 3,
                    CourseId = 2,
                    AttendanceDate = today.AddDays(-3),
                    Status = "Present",
                    Notes = null
                },
                // Diana's attendances for Mobile Dev
                new Attendance
                {
                    Id = 9,
                    StudentId = 4,
                    CourseId = 2,
                    AttendanceDate = today.AddDays(-5),
                    Status = "Permission",
                    Notes = "Doctor appointment"
                },
                new Attendance
                {
                    Id = 10,
                    StudentId = 4,
                    CourseId = 2,
                    AttendanceDate = today.AddDays(-4),
                    Status = "Present",
                    Notes = null
                },
                // Edward's attendances for Database
                new Attendance
                {
                    Id = 11,
                    StudentId = 5,
                    CourseId = 3,
                    AttendanceDate = today.AddDays(-5),
                    Status = "Present",
                    Notes = null
                },
                new Attendance
                {
                    Id = 12,
                    StudentId = 5,
                    CourseId = 3,
                    AttendanceDate = today.AddDays(-4),
                    Status = "Present",
                    Notes = null
                },
                new Attendance
                {
                    Id = 13,
                    StudentId = 5,
                    CourseId = 3,
                    AttendanceDate = today.AddDays(-3),
                    Status = "Present",
                    Notes = null
                },
                // Fiona's attendances for Database
                new Attendance
                {
                    Id = 14,
                    StudentId = 6,
                    CourseId = 3,
                    AttendanceDate = today.AddDays(-5),
                    Status = "Absent",
                    Notes = "No reason provided"
                },
                new Attendance
                {
                    Id = 15,
                    StudentId = 6,
                    CourseId = 3,
                    AttendanceDate = today.AddDays(-4),
                    Status = "Present",
                    Notes = null
                }
            };
        }
    }
}