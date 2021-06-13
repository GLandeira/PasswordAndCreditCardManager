using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain;


namespace Repository
{
    public class DataBreachTypeConfiguration : EntityTypeConfiguration<DataBreach>
    {
        public DataBreachTypeConfiguration()
        {
            this.HasKey(d => d.DataBreachID);
            
        }
    }
}
