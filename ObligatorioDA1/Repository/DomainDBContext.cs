using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public DbSet<DataBreach> DataBreaches { get; set; }
        public DbSet<PasswordHistory> PasswordHistory { get; set; }

        public DomainDBContext() : base("name=DomainDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CreditCardTypeConfiguration());
            modelBuilder.Configurations.Add(new UserCreditCardTypeConfiguration());
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
            modelBuilder.Configurations.Add(new UserCategoryTypeConfiguration());
            modelBuilder.Configurations.Add(new UserPasswordTypeConfiguration());
            modelBuilder.Configurations.Add(new DataBreachTypeConfiguration());
            modelBuilder.Configurations.Add(new PasswordHistoryTypeConfiguration());
            modelBuilder.Configurations.Add(new PasswordTypeConfiguration());
        }
    }
}
