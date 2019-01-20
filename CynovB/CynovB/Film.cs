using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CynovB
{
    class Film
    {
        public int FilmId { get; set; }
        public ICollection<LongMetrage> LongMetrage { get; set; }
        public ICollection<CourtMetrage> CourtMetrage { get; set; }
        public ICollection<Serie> Serie { get; set; }
        public Salle Salle { get; set; }
    }
}
