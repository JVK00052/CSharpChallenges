using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanChallenge
{
    class VehicleRepository
    {

        private List<Vehicle> _gasVehicles = new List<Vehicle>();
        private List<Vehicle> _electricVehicles = new List<Vehicle>();
        private List<Vehicle> _hybridVehicles = new List<Vehicle>();

        public void AddToGasVehicles(Vehicle vehicle)
        {
            _gasVehicles.Add(vehicle);
        }
        public void AddToElectricVehicles(Vehicle vehicle)
        {
            _electricVehicles.Add(vehicle);
        }
        public void AddToHybridVehicles(Vehicle vehicle)
        {
            _hybridVehicles.Add(vehicle);
        }

        public void RemoveGasVehicles(int vehicleID)
        {
            foreach (Vehicle vehicle in _gasVehicles)
            {
                if (vehicle.VehicleID == vehicleID)
                {
                    _gasVehicles.Remove(vehicle);
                }
            }
        }
        public void RemoveElectricVehicles(int vehicleID)
        {
            foreach (Vehicle vehicle in _gasVehicles)
            {
                if (vehicle.VehicleID == vehicleID)
                {
                    _electricVehicles.Remove(vehicle);
                }
            }
        }
        public void RemoveHybridVehicles(int vehicleID)
        {
            foreach (Vehicle vehicle in _gasVehicles)
            {
                if (vehicle.VehicleID == vehicleID)
                {
                    _hybridVehicles.Remove(vehicle);
                }
            }
        }

        public List<Vehicle> GetGasVehicles()
        {
            return _gasVehicles;
        }
        public List<Vehicle> GetElectricVehicles()
        {
            return _electricVehicles;
        }
        public List<Vehicle> GetHyrbidVehicles()
        {
            return _hybridVehicles;
        }
    }
}
