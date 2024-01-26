using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    /// Fonksiyonlar az satırdan oluşmalıdır.
    /// 
    /// “The first rule of functions is that they should be small.
    /// The second rule of functions is that they should be smaller than that.” — Robert C. Martin
    /// </summary>

    //BAD
    public class BadGreetings
    {
        public void Greetings(string timePhase)
        {
            if (timePhase == "morning")
            {
                Console.WriteLine("Good Morning");
            }
            else if (timePhase == "afternoon")
            {
                Console.WriteLine("Good Afternoon");
            }
            else if (timePhase == "evening")
            {
                Console.WriteLine("Good Evening");
            }
            else
            {
                Console.WriteLine("Good Night");
            }
        }
    }
    //GOOD

    //Greetings metodunu parçalara ayırarak metodun daha kısa olmasını sağlayalım.
    public class GoodGreetings
    {
        public void PrintGreeting(string greeting)
        {
            Console.WriteLine(greeting);
        }

        public void Greet(string timePhase)
        {
            string greeting = GetGreeting(timePhase);
            PrintGreeting(greeting);
        }

        public string GetGreeting(string timePhase)
        {
            return "Good " + timePhase;
        }
    }
}
