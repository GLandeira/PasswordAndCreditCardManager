using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain;

namespace Repository
{
    public class UserCategoryTypeConfiguration : EntityTypeConfiguration<UserCategory>
    {
        public UserCategoryTypeConfiguration()
        {
            this.HasMany(c => c.Categories)
                .WithRequired(cat => cat.UserCategory)
                .WillCascadeOnDelete(true);
        }
    }
}
