using Microsoft.EntityFrameworkCore;
using WebAppCleanArch.Domain.Entities;
using WebAppCleanArch.Domain.Seeds;

namespace WebAppCleanArch.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            ConfigureRelationships(modelBuilder);

            // Seed data
            SeedDatabase(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // Student -> Course (One-to-Many, nullable)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.SetNull);

            // Enrollment -> Student (Many-to-One)
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Enrollment -> Course (Many-to-One)
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Attendance -> Student (Many-to-One)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Attendance -> Course (Many-to-One)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Course)
                .WithMany(c => c.Attendances)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            // Seed Courses
            modelBuilder.Entity<Course>().HasData(SeedData.GetCourses());

            // Seed Students
            modelBuilder.Entity<Student>().HasData(SeedData.GetStudents());

            // Seed Enrollments
            modelBuilder.Entity<Enrollment>().HasData(SeedData.GetEnrollments());

            // Seed Attendances
            modelBuilder.Entity<Attendance>().HasData(SeedData.GetAttendances());
        }
    }
}