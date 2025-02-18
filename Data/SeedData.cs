using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowyASP.NET.Models;

namespace ProjektZaliczeniowyASP.NET.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Studenci.Any() || context.Kursy.Any()) return;

                var studenci = new List<StudentModel>
                {
                    new StudentModel { Imie = "Jan", Nazwisko = "Kowalski", Email = "jan@example.com" },
                    new StudentModel { Imie = "Anna", Nazwisko = "Nowak", Email = "anna@example.com" }
                };

                var kursy = new List<KursModel>
                {
                    new KursModel { Nazwa = "Programowanie w C#", Opis = "Podstawy C# i .NET" },
                    new KursModel { Nazwa = "Bazy danych", Opis = "SQL i Entity Framework" }
                };

                context.Studenci.AddRange(studenci);
                context.Kursy.AddRange(kursy);
                context.SaveChanges();
            }
        }
    }
}
