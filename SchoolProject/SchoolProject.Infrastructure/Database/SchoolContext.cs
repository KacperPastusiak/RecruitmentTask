using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.DatabaseStructure;

namespace SchoolProject.Infrastructure.Database
{
    /// <summary>
    /// Represents school database context.
    /// </summary>
    public class SchoolContext : DbContext
    {
        /// <summary>
        /// Create a new instance of a class <see cref="SchoolContext"/>.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        { }

        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolClass>()
                        .HasOne(sc => sc.Tutor)
                        .WithOne(t => t.SchoolClass);

            modelBuilder.Entity<SchoolClass>()
                        .HasKey(sc => sc.ID);

            modelBuilder.Entity<SchoolClass>()
                        .HasIndex(sc => sc.Group)
                        .IsUnique();

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
