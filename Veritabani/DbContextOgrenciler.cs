using BeltekMvcWebApp.Models;
using Microsoft.EntityFrameworkCore;
using BeltekMvcWebApp;

namespace BeltekMvcWebApp.Veritabani

{
    public class DbContextOgrenciler : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0CKK07Q\\SQLEXPRESS;Integrated Security=true;Initial Catalog=OkulDbEFMY;TrustServerCertificate=True;");
        }
    }
}
