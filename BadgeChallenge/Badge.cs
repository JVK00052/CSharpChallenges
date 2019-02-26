using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeChallenge
{
   public class Badge
    {
        public Badge() { }
        public Badge(int id, List<string> doors)
        {
            BadgeID = id;
            Doors = doors;
        }
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }
    }
}
