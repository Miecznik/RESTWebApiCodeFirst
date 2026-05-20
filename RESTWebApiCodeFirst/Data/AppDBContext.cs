using Microsoft.EntityFrameworkCore;
using RESTWebApiCodeFirst.Entities;

namespace RESTWebApiCodeFirst.Data;

public class AppDBContext : DbContext
{
    protected AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<PCs>  PCs { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<PCComponents> PCComponents { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PCs>().HasData(
            new List<PCs>()
            {
                new PCs() { Id = 1, Name = "Gaming Beast X1", Weight = 3.2f, Warranty = 36, CreatedAt = new DateTime(2024, 1, 10), Stock = 5 },
                new PCs { Id = 2, Name = "Office Pro 200", Weight = 2.1f, Warranty = 24, CreatedAt = new DateTime(2023, 6, 15), Stock = 15 },
                new PCs { Id = 3, Name = "UltraBook Slim Z", Weight = 1.3f, Warranty = 12, CreatedAt = new DateTime(2025, 3, 5), Stock = 8 },
                new PCs { Id = 4, Name = "Workstation Titan", Weight = 4.5f, Warranty = 48, CreatedAt = new DateTime(2022, 11, 20), Stock = 3 },
                new PCs { Id = 5, Name = "Home Basic PC", Weight = 2.8f, Warranty = 18, CreatedAt = new DateTime(2024, 8, 1), Stock = 20 }
            }
        );
        modelBuilder.Entity<PCComponents>().HasData(
            new List<PCComponents>()
            { 
                new PCComponents { PCId = 1, ComponentCode = "CPU001", Amount = 1 },
            new PCComponents { PCId = 1, ComponentCode = "GPU001", Amount = 1 },
            new PCComponents { PCId = 2, ComponentCode = "CPU001", Amount = 1 },
            new PCComponents { PCId = 2, ComponentCode = "RAM001", Amount = 2 },
            new PCComponents { PCId = 3, ComponentCode = "SSD001", Amount = 1 },
            new PCComponents { PCId = 3, ComponentCode = "RAM001", Amount = 1 },
            new PCComponents { PCId = 4, ComponentCode = "CPU001", Amount = 2 },
            new PCComponents { PCId = 4, ComponentCode = "GPU001", Amount = 2 },
            new PCComponents { PCId = 5, ComponentCode = "PSU001", Amount = 1 }
            });
        modelBuilder.Entity<ComponentTypes>().HasData(
            new List<ComponentTypes>()
            {
                new ComponentTypes { Id = 1, Abbreviation = "CPU", Name = "Processor" },
                new ComponentTypes { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
                new ComponentTypes { Id = 3, Abbreviation = "RAM", Name = "Memory" },
                new ComponentTypes { Id = 4, Abbreviation = "SSD", Name = "Storage" },
                new ComponentTypes { Id = 5, Abbreviation = "PSU", Name = "Power Supply" }
            });
        modelBuilder.Entity<ComponentManufacturers>().HasData(
            new List<ComponentManufacturers>()
            {
                new ComponentManufacturers { Id = 1, Abbreviation = "INT", FullName = "Intel", FoundationDate = new DateTime(1968, 7, 18) },
                new ComponentManufacturers { Id = 2, Abbreviation = "AMD", FullName = "AMD", FoundationDate = new DateTime(1969, 5, 1) },
                new ComponentManufacturers { Id = 3, Abbreviation = "NV", FullName = "NVIDIA", FoundationDate = new DateTime(1993, 4, 5) },
                new ComponentManufacturers { Id = 4, Abbreviation = "SMS", FullName = "Samsung", FoundationDate = new DateTime(1938, 3, 1) },
                new ComponentManufacturers { Id = 5, Abbreviation = "CRS", FullName = "Corsair", FoundationDate = new DateTime(1994, 1, 1) }
            });
        modelBuilder.Entity<Components>().HasData(
        
            new List<Components>()
            {
                new Components { Code = "CPU001", Name = "Intel i7", Description = "8-core processor", ComponentManufacturersId = 1, ComponentTypesId = 1 },
                new Components { Code = "GPU001", Name = "RTX 4070", Description = "Gaming GPU", ComponentManufacturersId = 3, ComponentTypesId = 2 },
                new Components { Code = "RAM001", Name = "16GB DDR4", Description = "Memory module", ComponentManufacturersId = 4, ComponentTypesId = 3 },
                new Components { Code = "SSD001", Name = "1TB SSD", Description = "Fast storage", ComponentManufacturersId = 4, ComponentTypesId = 4 },
                new Components { Code = "PSU001", Name = "750W PSU", Description = "Power supply", ComponentManufacturersId = 5, ComponentTypesId = 5 }
            }
        );
        

    }
}

