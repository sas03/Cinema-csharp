using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CynovB
{
    class LongMetrage
    {
        public int LongMetrageId { get; set; }
        public string LongMetrageTitre { get; set; }
        public int HoraireLongMetrage { get; set; }
        //public DateTime HoraireLongMetrage { get; set; }
        public bool TroisD { get; set; }
        public bool VO { get; set; }
        //une adresse est reliée à un utilisateur(clé étrangère)
        public Film Film { get; set; }
    }
}
