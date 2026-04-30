using Emergency_Ambulance_Dispatch_System.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Ambulance_Dispatch_System.Core_Models
{
    public  class EmergencyCase
    {
        public string CaseNo { get; }
        public Patient Patient { get; set; }
        public Ambulance? AssignedAmbulance { get; private set; }
        public EmergencyStatus Status { get; private set; }
        public Priority Priority { get; private set; }
        public EmergencyCase(Patient patient, Priority priority) 
        {
            CaseNo = Helpers.Helper.GenerateCaseNo();
            Patient = patient;
            Status = EmergencyStatus.Created;
            Priority = priority;
            
           
            
        }

    }
}
