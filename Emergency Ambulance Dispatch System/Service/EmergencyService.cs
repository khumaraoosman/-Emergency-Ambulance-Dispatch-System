using Emergency_Ambulance_Dispatch_System.Core_Models;
using Emergency_Ambulance_Dispatch_System.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Emergency_Ambulance_Dispatch_System.Service
{
    internal class EmergencyService
    {
        List<EmergencyCase> cases = new List<EmergencyCase>();
        List<Ambulance> ambulance = new List<Ambulance>();
        public void CreateEmergencyCase(Patient patient, Priority priority)
        {
            EmergencyCase newCase = new EmergencyCase(patient, priority);
            cases.Add(newCase);
        }
        public void AssignAmbulance(string caseNo)
        {
            var ambulance = GetAvailableAmbulances().First();
            if (ambulance != null)
            {
                var emergencyCase = cases.FirstOrDefault(x => x.CaseNo == caseNo);
                if (emergencyCase != null)
                {

                    emergencyCase.AssignedAmbulance = ambulance;
                    emergencyCase.Status = Enum.EmergencyStatus.Assigned;
                    Console.WriteLine(" Ambulans teyin olundu");
                    ambulance.IsAvailable = false;
                }
            }
        }
        public void StartDispatch(string caseNo)
        {
            var emergencyCase = cases.FirstOrDefault(x => x.CaseNo == caseNo);
            if (emergencyCase != null)
            {
                if (emergencyCase.AssignedAmbulance != null)
                {
                    emergencyCase.Status = Enum.EmergencyStatus.OnRoute;
                    Console.WriteLine("Yola cixildi");
                }
                else
                {
                    Console.WriteLine("Ambulans teyin olunmayib");
                }
            }
        }
        public void CompleteCase(string caseNo)
        {
            var emergencyCase = cases.FirstOrDefault(x => x.CaseNo == caseNo);
            if (emergencyCase != null)
            {
                emergencyCase.Status = Enum.EmergencyStatus.Completed;
                if (emergencyCase.AssignedAmbulance != null)
                {
                    emergencyCase.AssignedAmbulance.IsAvailable = true;
                    Console.WriteLine("mission completed");
                }
            }
        }
        public EmergencyCase GetCase(string caseNo)
        {
            if (string.IsNullOrEmpty(caseNo))
            {
                throw new ArgumentException("Case number cannot be null or empty.", nameof(caseNo));
            }
            EmergencyCase data = cases.First(x => x.CaseNo == caseNo);
            return data;
        }
        public List<EmergencyCase> GetAllCases()
        {
            return cases;
        }
        public List<EmergencyCase> GetCasesByStatus(string status)
        {
            return cases.FindAll(x => x.Status.ToString() == status);
        }
        public List<EmergencyCase> GetHighPriorityCases()
        {
            return cases.FindAll(x => x.Priority == Priority.High);

        }
        public List<Ambulance> GetAvailableAmbulances()
        {
            return ambulance.FindAll(x => x.IsAvailable);
        }
        public void SystemInfo()
        {
            Console.WriteLine($"Total Cases: {cases.Count}");
            Console.WriteLine($"Available Ambulances: {GetAvailableAmbulances().Count}");
            Console.WriteLine($"Completed Cases: {cases.Count(x => x.Status == Enum.EmergencyStatus.Completed)}");
            Console.WriteLine($"Active Cases: {cases.Count(x => x.Status != Enum.EmergencyStatus.Completed)}");

        }
    }
}
