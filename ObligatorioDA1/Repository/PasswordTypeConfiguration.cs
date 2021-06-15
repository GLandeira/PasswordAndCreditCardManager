using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repository
{
    public class PasswordTypeConfiguration : EntityTypeConfiguration<Password>
    {
        public PasswordTypeConfiguration()
        {
            this.HasMany(p => p.UsersSharedWith)
                .WithMany();

            
        }
    }
}
