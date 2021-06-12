using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserDataBreaches
    {
        public int UserDataBreachesID { get; set; }
        public List<DataBreach> DataBreaches { get; set; }

        public void AddDataBreach(DataBreach dataBreach)
        {
            throw new NotImplementedException();
        }

        public void GetDataBreach()
        {

        }
    }
}
