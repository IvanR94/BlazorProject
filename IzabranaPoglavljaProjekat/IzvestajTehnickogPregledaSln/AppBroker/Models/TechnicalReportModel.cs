using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBroker.Models
{
    public class TechnicalReportModel
    {
        public int BrojIzvestajaID { get; set; }
        public DateTime DatumVrsenjaTehnickogPregleda { get; set; }
        public bool StatusTehnickogPregleda { get; set; }
        public string Napomena { get; set; }
        public int ZaposleniID { get; set; }
        public string ImePrezimeZaposlenog { get; set; }
        public int TipTehnickogPregledaID { get; set; }
        public string TipTehnickogPregleda { get; set; }
        public string Vozilo { get; set; }
        public List<DefectiveItems> DefectiveItemsList { get; set; }
    }
}
