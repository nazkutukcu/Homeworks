using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.SOLID.ISP
{
    /// <summary>
    /// Interface Segregation Principle (ISP): Genel amaçlı interface oluşturma.
    /// Client'lara özgü interface oluştur.
    /// </summary>
    
    //BAD
    public interface IEmployee
    {
        List<string> GetAllNames();
        void WorkFromHome();
        void GoToOffice();
        void AttendMeeting();
        void StuckInTraffic();
        void DressPajamas();
    }

    //HomeOfficeModule ve GoToOfficeModule diye 2 tane modülümüz olsun.
    public class BadHomeOfficeModule 
    {
        private readonly IEmployee _employee;
        public BadHomeOfficeModule(IEmployee employee)
        {
            _employee = employee;
        }
        public List<string> GetAllEmployeeNames()
        {
            return _employee.GetAllNames();
        }       
    }

    //GOOD
    public interface IHomeOfficeModule
    {
        List<string> GetAllNames();
        void WorkFromHome();
        void AttendMeeting(); 
        void DressPajamas();
    }
    public interface IGoToOfficeModule
    {
        List<string> GetAllNames();
        void GoToOffice();
        void AttendMeeting();
        void StuckInTraffic();
    }

    public class GoodHomeOfficeModule
    {
        private readonly IHomeOfficeModule _employee;
        public GoodHomeOfficeModule(IHomeOfficeModule employee)
        {
            _employee = employee;
        }
        public List<string> GetAllEmployeeNames()
        {
            //Artık sadece home office client'ına özel methodlar olucak.
            return _employee.GetAllNames(); 
        }
    }
    public class GoodGoToOfficeModule
    {
        private readonly IGoToOfficeModule _employee;
        public GoodGoToOfficeModule(IGoToOfficeModule employee)
        {
            _employee = employee;
        }
        public List<string> GetAllEmployeeNames()
        {
            //Artık sadece office'e giden client'a özel methodlar olucak.
            return _employee.GetAllNames();
        }
    }
}
