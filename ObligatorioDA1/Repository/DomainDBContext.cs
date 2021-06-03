using System;
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
        public DbSet<CreditCard> CreditCards { get; set;}
        
        public DomainDBContext() : base("name=DomainDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CreditCardTypeConfiguration());
        }
    }
}
