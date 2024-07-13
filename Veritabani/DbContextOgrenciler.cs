using BeltekMvcWebApp.Models;
using Microsoft.EntityFrameworkCore;
using BeltekMvcWebApp;

namespace BeltekMvcWebApp.Veritabani

{
    public class DbContextOgrenciler : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0CKK07Q\\SQLEXPRESS;Integrated Security=true;Initial Catalog=OkulDbEFMY;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Student Entity Configuration
            modelBuilder.Entity<Student>().ToTable("tblStudent");
            modelBuilder.Entity<Student>().Property("Name").HasColumnType("nvarchar").HasMaxLength(25).IsRequired();
            modelBuilder.Entity<Student>().Property("Surname").HasColumnType("nvarchar").HasMaxLength(35).IsRequired();
            modelBuilder.Entity<Student>().HasKey(s => s.StudentId);


            // Class Entity Configuration
            modelBuilder.Entity<Class>().ToTable("tblClasses");
            modelBuilder.Entity<Class>().Property("ClassName").HasColumnType("nvarchar").HasMaxLength(15).IsRequired();
            modelBuilder.Entity<Class>().Property("Quota").HasMaxLength(32);
            modelBuilder.Entity<Class>().HasKey(c => c.ClassId);
            modelBuilder.Entity<Class>().HasMany(c => c.Students).WithOne(s => s.Class).HasForeignKey(s => s.ClassId).OnDelete(DeleteBehavior.Cascade);        
            
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<Class>())
            {
                //Sınıf clasına yada öğrenci için sınıf atamasını takip et ekleme veya düzenleme apıldığında sınıftaki öğrenci sayısı 30 dan fazla ise hata fırlat
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    if (entry.Entity.Students.Count > 30)
                    {
                        throw new InvalidOperationException("Bir sınıf da 30'dan fazla Öğrenci bulunamaz!!!");
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
