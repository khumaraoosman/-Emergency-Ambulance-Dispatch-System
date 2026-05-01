using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Ambulance_Dispatch_System.Core_Models
{
    public class Patient
    {
        private static int _id = 1;
        public int Id { get; }
        public string FullName { get; set; }
        public string PhoneNumber { get;set; }
        public string Location { get; set; }

        public Patient(string fullName, string phoneNumber, string location)
        {
        
            Id = _id++;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Location = location;

        }

    }
}
