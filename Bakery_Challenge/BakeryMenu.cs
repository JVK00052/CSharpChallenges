using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery_Challenge
{
    public enum BakeType { Bread, Cake, Pastry, Pies }
    public class BakeryMenu
    {
        public BakeryMenu() { }

        public BakeryMenu(string name, BakeType kind, string cname, int obs, decimal oc)
        {
            Kind = kind;
            ProductName = name;
            CustomerName = cname;
            OrderBatchSize = obs;
            OrderCost = oc;
        }
        public string ProductName { get; set; }
        public BakeType Kind { get; set; }
        public string CustomerName { get; set; }
        public int OrderBatchSize { get; set; }
        public decimal OrderCost { get; set; }
    }
}