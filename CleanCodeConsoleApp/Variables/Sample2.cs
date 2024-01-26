using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Variables
{
    /// <summary>
    /// "Avoid mental mapping" prensibi, kodun okuyan kişinin bir değişkenin ne anlama geldiğini çözmek
    /// için zorlamamasını, açık ve anlaşılır olmasını önerir.
    /// </summary>
    public class CityProcessor
    {
        // BAD
        public void ProcessCitiesBad()
        {
            var l = new[] { "Istanbul", "Paris", "Tokyo" };

            for (var i = 0; i < l.Count(); i++)
            {
                var ci = l[i];
                DoSomething(ci);
                DoSomeOtherThing();

                // ...
                // ...
                // ...
                // Peki `ci` değişkeni tam olarak ne için kullanılmış anlaşılmıyor.
                PerformAction(ci);
            }
        }

        // GOOD
        public void ProcessCitiesGood()
        {
            var cities = new[] { "Istanbul", "Paris", "Tokyo" };

            foreach (var city in cities)
            {
                DoSomething(city);
                DoSomeOtherThing();

                // ...
                // ...
                // ...
                PerformAction(city);
            }
        }

        private void DoSomething(string city)
        {
            // Do something with the city...
        }

        private void DoSomeOtherThing()
        {
            // Do some other thing...
        }

        private void PerformAction(string city)
        {
            // Perform an action using the city...
        }
    }
}
