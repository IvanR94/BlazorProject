using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBroker.Models
{
    public class DefectiveItems
    {
        public int NeispravneStavkeID { get; set; }
        public int BrojIzvestajaID { get; set; }
        public string NazivNeispravnogDela { get; set; }
        public string OpisNeispravnosti { get; set; }
    }
}
