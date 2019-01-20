using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CynovB
{
    class Serie
    {
        public int SerieId { get; set; }
        public string SerieTitre { get; set; }
        public int HoraireSerie { get; set; }
        //public DateTime HoraireSerie { get; set; }
        public bool TroisD { get; set; }
        public bool VO { get; set; }
        //une adresse est reliée à un utilisateur(clé étrangère)
        public Film Film { get; set; }
    }
}
