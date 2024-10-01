using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_S
{
    public class AS_DbContext : DbContext
    {
        private readonly string _connectionstring;
        public AS_DbContext()
        {
            _connectionstring = "Server=Riyad\\SQLEXPRESS;Database=P_AS;User Id=riyad_C#;Password=riyad102;TrustServerCertificate=True";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionstring);
            }
             base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassSchedule>()
                 .HasKey(e => e.Id);

            modelBuilder.Entity<CourseStudent>()
            .HasOne(x => x.Student)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<CourseStudent>()
               .HasOne(x => x.Course)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(x => x.CourseId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }

        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
    }
}