using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.DatabaseStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Infrastructure.Database
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        { }

        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolClass>().ToTable("SchoolClass");

            modelBuilder.Entity<Tutor>()
                        .HasOne(t => t.SchoolClass)
                        .WithOne(sc => sc.Tutor);

            modelBuilder.Entity<Student>()
                        .HasOne(s => s.SchoolClass)
                        .WithMany(sc => sc.Students)
                        .HasForeignKey(s => s.SchoolClassId);
        }
    }
}
