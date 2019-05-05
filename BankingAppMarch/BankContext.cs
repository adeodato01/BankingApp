using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingAppMarch
{
    public class BankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BankApp;Integrated Security=True;Connect Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNumber).HasName("PK_Accounts");
                entity.Property(e => e.AccountNumber).ValueGeneratedOnAdd();
                entity.Property(e => e.EmailAddress).IsRequired().HasMaxLength(50);
                entity.Property(e => e.AccountType).IsRequired();
            });

            modelBuilder.Entity<Transaction>( entity => 
            {
                entity.HasKey(e => e.TransactionId).HasName("PK_Transactions");

                entity.Property(e => e.TransactionId).ValueGeneratedOnAdd();

                entity.Property(e => e.Amount).IsRequired();

                entity.HasOne(e => e.Account)
                    .WithMany()
                    .HasForeignKey(e => e.AccountNumber);
            });
        }
    }
}
