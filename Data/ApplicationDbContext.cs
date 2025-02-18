using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowyASP.NET.Models;

namespace ProjektZaliczeniowyASP.NET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<StudentModel> Studenci { get; set; }
        public DbSet<KursModel> Kursy { get; set; }
        public DbSet<ZapisNaKursModel> ZapisyNaKurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja Many-to-Many
            modelBuilder.Entity<ZapisNaKursModel>()
                .HasOne(z => z.Student)
                .WithMany(s => s.ZapisaneKursy)
                .HasForeignKey(z => z.StudentId);

            modelBuilder.Entity<ZapisNaKursModel>()
                .HasOne(z => z.Kurs)
                .WithMany(k => k.ZapisaniStudenci)
                .HasForeignKey(z => z.KursId);
        }
    }
}
