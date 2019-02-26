using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeChallenge
{
    class BadgeRepository
    {
        Dictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();
        
        public void AddToDictionary(Badge badge)
        {
            _dictionary.Add(badge.BadgeID, badge.Doors);
        }

        public Dictionary<int, List<string>> ReturnDictionary()
        {
            return _dictionary;
        }

        public Badge AddToListOfDoors(Badge badge, string nameOfDoors)
        {
            List<string> addList = badge.Doors;

            addList.Add(nameOfDoors);

            badge.Doors = addList;

            return badge;
        }

        public List<string> GetListOfDoors(Badge badge)
        {
            List<string> _list = badge.Doors;

            return _list;
        }
    }
}
