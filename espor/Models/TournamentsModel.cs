using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace espor.Models
{
    public class TournamentsModel
    {
        public int TournamentsId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Genel { get; set; }
        public string Kurallar { get; set; }
        public string Sponsorlar { get; set; }
    }
}
