using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Ambulance_Dispatch_System.Core_Models
{
    public class Ambulance
    {
        private static int _id = 1;
        public int Id { get; }
        public string PlateNumber { get; private set; }
        public string DriverName { get; private set; }
        public bool IsAvailable { get; private set; }

        public Ambulance(string plateNumber, string driverName, bool isavailable)
        {
            if (!string.IsNullOrWhiteSpace(plateNumber)) 
            {
                throw new Exception("PlateNumber sehvdir");
            }
            if (!string.IsNullOrWhiteSpace(driverName)) 
            {
                throw new Exception("DriverName sehvdir");
            }
         
            Id = _id++;
            DriverName = driverName;
            PlateNumber = plateNumber;
            IsAvailable = true;
        }


    }
}
