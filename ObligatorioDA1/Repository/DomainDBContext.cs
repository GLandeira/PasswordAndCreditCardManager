﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repository
{
    public class DomainDBContext : DbContext
    {
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<UserCreditCard> UserCreditCards { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDataBreaches> UserDataBreaches { get; set; }

        public DomainDBContext() : base("name=DomainDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CreditCardTypeConfiguration());

            modelBuilder.Entity<User>().HasKey(u => u.UserID);
            modelBuilder.Entity<User>()
                .HasRequired(u => u.UserCreditCards)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
                .HasRequired(u => u.UserPasswords)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
                .HasRequired(u => u.UserDataBreaches)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
                .HasRequired(u => u.UserCategories)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}
