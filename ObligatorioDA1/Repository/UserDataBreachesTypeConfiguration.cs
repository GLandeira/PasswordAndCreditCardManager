using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain;

namespace Repository
{
    public class UserDataBreachesTypeConfiguration : EntityTypeConfiguration<UserDataBreaches>
    {
        public UserDataBreachesTypeConfiguration()
        {
            this.HasKey(ud => ud.UserDataBreachesID);

            this.HasMany(d => d.DataBreaches)
                .WithRequired(db => db.UserDataBreaches)
                .WillCascadeOnDelete(true);

            this.Ignore(d => d.DataBreachesChecker);
        }
    }
}
