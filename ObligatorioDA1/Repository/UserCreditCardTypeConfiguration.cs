using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain;

namespace Repository
{
    public class UserCreditCardTypeConfiguration : EntityTypeConfiguration<UserCreditCard>
    {

        public UserCreditCardTypeConfiguration()
        {
            this.HasMany(c => c.CreditCards)
            .WithRequired(cc => cc.UserCreditCard)
            .WillCascadeOnDelete(true);
        }
        
    }
}
