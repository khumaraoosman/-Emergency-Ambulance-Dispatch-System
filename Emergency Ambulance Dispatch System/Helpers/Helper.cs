using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Ambulance_Dispatch_System.Helpers
{
    public static class Helper
    {
        private static int _caseCounter = 1001;
        public static bool CheckFullName(string fullName) 
        {
           if (string.IsNullOrWhiteSpace(fullName)) 
           {
                return false;
           }
            return true;
        }
        public static bool CheckPhoneNumber(string phoneNumber) 
        {
            if (string.IsNullOrWhiteSpace(phoneNumber)) 
            {
                return false;
            }
            
            if (phoneNumber.Length < 10 || phoneNumber.Length > 15) 
            {
                return false;
            }
            return true;
        }
        public static bool CheckLocation(string location) 
        {
            if (string.IsNullOrWhiteSpace(location)) 
            {
                return false;   
            }
            if (location.Length < 5) 
            {
                return false;
            }
            return true;
            
        }
        public static string  GenerateCaseNo() 
        {
            return "EMG" + _caseCounter++;
        }
    }
}
