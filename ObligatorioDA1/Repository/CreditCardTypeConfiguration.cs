using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain;

namespace Repository
{
    public class CreditCardTypeConfiguration : EntityTypeConfiguration<CreditCard>
    {
        public CreditCardTypeConfiguration()
        {
            this.HasKey(c => c.Number);
        }
    }
}
