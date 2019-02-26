using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanChallenge
{
    public enum VehicleType { Hybrid, Electric, Gas}
    public class Vehicle
    {
        public Vehicle() { }
        public Vehicle(VehicleType type, int id, string name, string model)
        {
            VehicleRunType = type;
            VehicleID = id;
            VehicleName = name;
            VehicleModel = model;
        }
        public VehicleType VehicleRunType { get; set; }
        public int VehicleID { get; set; }
        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }
    }
}
