using BarbershopMDM.Models;
using Microsoft.EntityFrameworkCore;

namespace BarbershopMDM.Data
{
    class DataContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Consumables> Consumables { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderContent> OrderContents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.sqlite3");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(x => x.Id)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(x => x.Login)
                .IsUnique();

            modelBuilder.Entity<Supplier>()
                .HasIndex(x => x.Id)
                .IsUnique();

            modelBuilder.Entity<Consumables>()
                .HasIndex(x => x.Id)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .HasIndex(x => x.Id)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.Orders);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Supplier)
                .WithMany(x => x.Orders);

            modelBuilder.Entity<OrderContent>()
                .HasIndex(x => x.Id)
                .IsUnique();

            modelBuilder.Entity<OrderContent>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderContents);

            modelBuilder.Entity<OrderContent>()
                .HasOne(x => x.Consumables)
                .WithMany(x => x.OrdersContents);
        }
    }
}
