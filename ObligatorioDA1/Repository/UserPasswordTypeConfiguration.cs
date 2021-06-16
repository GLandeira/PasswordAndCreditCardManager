using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain;

namespace Repository
{
    class UserPasswordTypeConfiguration : EntityTypeConfiguration<UserPassword>
    {
        public UserPasswordTypeConfiguration()
        {
            this.HasMany(p => p.Passwords)
                .WithRequired(p => p.UserPassword)
                .WillCascadeOnDelete(true);

            this.Ignore(p => p.DecryptedPasswords);
        }
    }
}