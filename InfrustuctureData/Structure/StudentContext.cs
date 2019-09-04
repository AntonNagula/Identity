using InfrustuctureData.Configurations;
using InfrustuctureData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrustuctureData.Structure
{
    public class StudentContext : DbContext
    {
        public DbSet<DataStudent> Students { get; set; }
        public DbSet<DataLesson> Lessons { get; set; }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public StudentContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.Entity<DataStudent>().HasData(
            new DataStudent[]
            {                
                new DataStudent { Id=1, Name="somemail@mail.ru"},
                new DataStudent { Id=2, Name="mail@mail.ru"},
            });

            modelBuilder.Entity<DataLesson>().HasData(
            new DataLesson[]
            {
                new DataLesson { Id=1, Name="Математика", StudentNumber=1},
                new DataLesson { Id=2, Name="Физика", StudentNumber=1},
                new DataLesson { Id=3, Name="Физика", StudentNumber=2},
                new DataLesson { Id=4, Name="Химия", StudentNumber=2},
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
