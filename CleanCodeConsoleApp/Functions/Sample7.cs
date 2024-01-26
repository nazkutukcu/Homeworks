using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    /// "Always encapsulate conditionals" prensibi, koşullu ifadelerin mümkünse bir metod içinde saklanmasını ve
    /// sarmalanmasını (encapsulation) önerir. 
    /// </summary>

    //BAD
    public class BadCustomer
    {
        public int Age { get; set; }

        public void ProcessOrder()
        {
            if (Age >= 18)
            {
                // Sipariş işlemleri yetişkin müşteri için...
                Console.WriteLine("Order processed for adult customer.");
            }
            else
            {
                // Sipariş işlemleri küçük müşteri için...
                Console.WriteLine("Order processed for minor customer.");
            }
        }
    }

    //GOOD
    public class GoodCustomer
    {
        public int Age { get; set; }

        public bool IsAdult()
        {
            return Age >= 18;
        }

        public void ProcessOrder()
        {
            if (IsAdult())
            {
                // Sipariş işlemleri yetişkin müşteri için...
                Console.WriteLine("Order processed for adult customer.");
            }
            else
            {
                // Sipariş işlemleri küçük müşteri için...
                Console.WriteLine("Order processed for minor customer.");
            }
        }
    }


}
