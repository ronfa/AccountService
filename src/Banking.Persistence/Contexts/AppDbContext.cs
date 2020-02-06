using System;
using Banking.Business.Model;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Customer>().HasKey(p => p.Id);
            builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Entity<Customer>().Property(p => p.Surname).IsRequired().HasMaxLength(200);
            builder.Entity<Customer>().HasMany(a => a.Accounts).WithOne(a => a.Customer).HasForeignKey(a => a.CustomerId);

            builder.Entity<Customer>().HasData
            (
                new Customer { Id = 1, Name = "John", Surname = "Bryan" },
                new Customer { Id = 2, Name = "Lisa", Surname = "Roberts", },
                new Customer { Id = 3, Name = "Jillian", Surname = "Michaels" }
            );

            builder.Entity<Account>().ToTable("Accounts");
            builder.Entity<Account>().HasKey(p => p.Id);
            builder.Entity<Account>().Property(p => p.Id).IsRequired();
            builder.Entity<Account>().Property(p => p.CustomerId).IsRequired();
            builder.Entity<Account>().HasMany(a => a.Transactions).WithOne(a => a.Account).HasForeignKey(a => a.AccountId);

            builder.Entity<Account>().HasData
            (
                new Account { Id = 1, CustomerId = 1 },
                new Account { Id = 2, CustomerId = 1 },
                new Account { Id = 3, CustomerId = 2 },
                new Account { Id = 4, CustomerId = 2 },
                new Account { Id = 5, CustomerId = 3 }
            );

            builder.Entity<Transaction>().ToTable("Transactions");
            builder.Entity<Transaction>().HasKey(p => p.Id);
            builder.Entity<Transaction>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Transaction>().Property(p => p.AccountId).IsRequired();
            builder.Entity<Transaction>().Property(p => p.Amount).IsRequired();
            builder.Entity<Transaction>().Property(p => p.Timestamp).IsRequired();
            builder.Entity<Transaction>().Property(p => p.Description).IsRequired();

            builder.Entity<Transaction>().HasData 
            (
                new Transaction { Id = 1, AccountId = 1, Timestamp = DateTime.UtcNow, Amount = 2.55,  Description = "Monthly Credit" },
                new Transaction { Id = 2, AccountId = 1, Timestamp = DateTime.UtcNow.AddDays(-10), Amount = 50.21, Description = "Transaction ref: 458711" },
                new Transaction { Id = 3, AccountId = 1, Timestamp = DateTime.UtcNow.AddDays(-50).AddMinutes(-400), Amount = -20.61, Description = "Starbucks Schiphol" },

                new Transaction { Id = 4, AccountId = 2, Timestamp = DateTime.UtcNow, Amount = 450.00, Description = "ABN Credit" },
                new Transaction { Id = 5, AccountId = 2, Timestamp = DateTime.UtcNow.AddDays(-20), Amount = -2.21, Description = "NS Trains" },
                new Transaction { Id = 6, AccountId = 2, Timestamp = DateTime.UtcNow.AddDays(-110), Amount = -330.61, Description = "Intertoys" },

                new Transaction { Id = 7, AccountId = 3, Timestamp = DateTime.UtcNow.AddDays(-20), Amount = 1008.00, Description = "Initial Credit" },
                new Transaction { Id = 8, AccountId = 3, Timestamp = DateTime.UtcNow, Amount = -67.21, Description = "Albert Heijn" },

                new Transaction { Id = 9, AccountId = 4, Timestamp = DateTime.UtcNow.AddDays(-70), Amount = 900.00, Description = "Initial Credit" },
                new Transaction { Id = 10, AccountId = 4, Timestamp = DateTime.UtcNow, Amount = -9.45, Description = "Etos Hilversum" },

                new Transaction { Id = 11, AccountId = 5, Timestamp = DateTime.UtcNow.AddDays(-30), Amount = 5414.00, Description = "ASR Refrence: 29180 " },
                new Transaction { Id = 12, AccountId = 5, Timestamp = DateTime.UtcNow.AddDays(-20), Amount = -899.45, Description = "Credit card payment" },
                new Transaction { Id = 13, AccountId = 5, Timestamp = DateTime.UtcNow, Amount = -32.45, Description = "Kriudvat Hilversum" }

            );

        }
    }
}