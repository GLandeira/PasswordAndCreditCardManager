using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain;

namespace Repository
{
    public class UserTypeConfiguration : EntityTypeConfiguration<User>
    {
        public UserTypeConfiguration()
        {
            this.HasKey(u => u.UserID);

            this.HasRequired(u => u.UserCreditCards)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(true);

            this.HasRequired(u => u.UserPasswords)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(true);

            this.HasRequired(u => u.UserDataBreaches)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(true);

            this.HasRequired(u => u.UserCategories)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(true);

            this.Ignore(u => u.Encryptor);
        }
    }
}
