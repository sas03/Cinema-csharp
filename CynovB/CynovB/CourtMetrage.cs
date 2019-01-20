using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CynovB
{
    class CourtMetrage
    {
        public int CourtMetrageId { get; set; }
        public string CourtMetrageTitre { get; set; }
        public int HoraireCourtMetrage { get; set; }
        //public DateTime HoraireCourtMetrage { get; set; }
        public bool TroisD { get; set; }
        public bool VO { get; set; }
        //une adresse est reliée à un utilisateur(clé étrangère)
        public Film Film { get; set; }
    }
}
