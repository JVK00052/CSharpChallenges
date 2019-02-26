using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingChallenge
{
   public class OutingRepository
    {
        private List<Outing> _outingList = new List<Outing>();

        public void AddEventToList(Outing outing)
        {
            _outingList.Add(outing);
        }
        public List<Outing> GetEvents()
        {
            return _outingList;
        }
    }
}
