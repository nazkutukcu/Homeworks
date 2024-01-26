using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    /// "Avoid type-checking" prensibi, tip kontrolünden kaçınılmasını ve yerine polymorphism'in veya
    /// kalıtımın kullanılmasını önerir.
    /// </summary>

    // BAD
    public class BadTravelAgency
    {
        public void PlanTravel(object traveler)
        {
            if (traveler.GetType() == typeof(Student))
            {
                // Öğrenci özel indirimleri ve planları...
                (traveler as Student).TravelTo(new Location("antalya"));
            }
            else if (traveler.GetType() == typeof(Employee))
            {
                // Çalışan için özel planlar...
                (traveler as Employee).TravelTo(new Location("antalya"));
            }
        }
    }

    // GOOD
    public class GoodTravelAgency
    {
        public void PlanTravel(Traveler traveler)
        {
            // Polimorfizm veya kalıtım kullanarak doğrudan TravelTo metodunu çağırabiliriz.
            traveler.TravelTo(new Location("antalya"));
        }
    }

    // Ortak bir arayüz veya temel sınıf
    public interface Traveler
    {
        void TravelTo(Location destination);
    }

    // Öğrenci sınıfı, Traveler arayüzünü uygular
    public class Student : Traveler
    {
        public void TravelTo(Location destination)
        {
            // Öğrenciye özgü seyahat işlemleri...
        }
    }

    // Çalışan sınıfı, Traveler arayüzünü uygular
    public class Employee : Traveler
    {
        public void TravelTo(Location destination)
        {
            // Çalışana özgü seyahat işlemleri...
        }
    }

    // Seyahat destinasyonunu temsil eden sınıf
    public class Location
    {
        public string Name { get; }

        public Location(string name)
        {
            Name = name;
        }
    }
}
