using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery_Challenge
{
    public class BakeryRepository
    {
        private List<BakeryMenu> _BakeryMenus = new List<BakeryMenu>();

        public void AddItemToList(BakeryMenu item)
        {
            _BakeryMenus.Add(item);
        }
        public void RemoveItemFromList(BakeryMenu item)
        {
            _BakeryMenus.Remove(item);
        }
        public List<BakeryMenu> GetBakeryMenus()
        {
            return _BakeryMenus;
        }

        public BakeryMenu FindItemFromMenu(string ProductName)
        {
            var item = new BakeryMenu();

            foreach(var BakeryMenu in _BakeryMenus)
            {
                if (ProductName == BakeryMenu.ProductName)
                {
                    item = BakeryMenu;
                    break;
                }
            }
            return item;
        }

        public decimal CalculateCost(BakeType type)
        {
            decimal totalCost = 100m;
            switch(type)
            {
                case BakeType.Bread:
                    totalCost += 500.01m;
                        break;
                case BakeType.Cake:
                        totalCost += 2000.0m;
                    break;
                case BakeType.Pastry:
                    totalCost += 200.10m;
                    break;
                case BakeType.Pies:
                    totalCost += 851.5m;
                    break;
            }
            return totalCost;
        }
    }
}
