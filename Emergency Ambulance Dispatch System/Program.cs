using Emergency_Ambulance_Dispatch_System.Core_Models;
using Emergency_Ambulance_Dispatch_System.Service;
using Emergency_Ambulance_Dispatch_System.Enum;
namespace Emergency_Ambulance_Dispatch_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choose;
            bool IsExit = false;
            string caseNo;
            Patient patient;
            Priority priority;
            string phoneNumber;
            string fullName;
            string location;
           
            EmergencyService service = new EmergencyService();
            do 
            {
                Console.WriteLine("\r\n1. Create Emergency Case\r\n2. Assign Ambulance\r\n3. Start Dispatch\r\n4. Complete Case\r\n5. Get Case by CaseNo\r\n6. Get All Cases\r\n7. Filter by Status\r\n8. High Priority Cases\r\n9. Available Ambulances\r\n10. System Info\r\n0. Exit");
                choose = Console.ReadLine()!;
                switch (choose) 
                {
                    case "1":
                    fullName:
                        Console.WriteLine("pasiyentin adini daxil edin");
                        fullName = Console.ReadLine()!;
                        if(!Helpers.Helper.CheckFullName(fullName))
                        {
                            Console.WriteLine("duzgun ad daxil edin");
                            goto fullName;
                        }
                    phoneNumber:
                        Console.WriteLine("pasiyentin telefon nomresini daxil edin");
                        phoneNumber = Console.ReadLine()!;
                        if(!Helpers.Helper.CheckPhoneNumber(phoneNumber))
                        {
                            Console.WriteLine("telefon nomresini duzgun daxil edin");
                            goto phoneNumber;
                        }
                    location:
                        Console.WriteLine("pasiyentin adresini daxil edin");
                        location = Console.ReadLine()!;
                        if (!Helpers.Helper.CheckLocation(location))
                        {
                            Console.WriteLine("adres daxil edin");
                            goto location;
                        }
                        patient = new Patient(fullName, phoneNumber, location);
                       

                    priotiret:
                        Console.WriteLine("prioritet daxil edin");
                        if (System.Enum.TryParse(typeof(Priority), Console.ReadLine(), true, out object? result))
                        {
                            priority = (Priority)result;
                        }
                        else
                        {
                            Console.WriteLine("duzgun prioritet daxil edin");
                            goto priotiret;
                        }
                        service.CreateEmergencyCase(patient, priority);
                        break;

                    case "2":
                    caseNo:
                        try
                        {
                            Console.WriteLine("CaseNo daxil edin");
                            caseNo = Console.ReadLine()!;
                            service.AssignAmbulance(caseNo);
                        }
                        catch (Exception)
                        {

                            goto caseNo;
                        }
                        break;

                    case "3":
                    caseNo1:
                        try
                        {
                            Console.WriteLine("CaseNo daxil edin");
                            caseNo = Console.ReadLine()!;
                            service.StartDispatch(caseNo);

                        }
                        catch (Exception)
                        {
                            goto caseNo1;
                        }
                        break;

                    case "4":
                        caseNo2:
                        try
                        {
                            Console.WriteLine("CaseNo daxil edin");
                            caseNo = Console.ReadLine()!;
                            service.CompleteCase(caseNo);
                        }
                        catch (Exception)
                        {

                            goto caseNo2;
                        }
                        break;

                    case "5":
                    caseNo3:
                        try
                        {
                            Console.WriteLine("CaseNo daxil edin");
                            caseNo = Console.ReadLine()!;
                            service.GetCase(caseNo);
                        }
                        catch (Exception)
                        {

                            goto caseNo3;
                        }
                        break;

                    case "6":
                        service.GetAllCases();
                        break;

                    case "7":
                        status:
                        Console.WriteLine("Status daxil edin (Created, Assigned, OnRoute, Completed)");
                        if (System.Enum.TryParse(typeof(EmergencyStatus), Console.ReadLine(), true, out object? resultStatus))
                        {
                             EmergencyStatus resultstatus = (EmergencyStatus)resultStatus;
                             service.GetCasesByStatus(resultstatus);
                        }
                        else
                        {
                            Console.WriteLine("duzgun status daxil edin");
                            goto status;
                        }
                        break;

                    case "8":
                        service.GetHighPriorityCases();
                        break;

                    case "9":
                        service.GetAvailableAmbulances();
                        break;

                    case "10":
                      service.SystemInfo();
                        break;
                     case "0":
                        IsExit = true;
                        break;
                    default:
                        Console.WriteLine("duzgun secim edin");
                        break;
                }
            } 
            while (!IsExit);
        }
    }
}
