using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain;


namespace Repository
{
    public class PasswordHistoryTypeConfiguration : EntityTypeConfiguration<PasswordHistory>
    {
        public PasswordHistoryTypeConfiguration()
        {
            this.HasKey(p => p.PasswordHistoryID);
            //this.HasOptional
        }
    }
}
