using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.SOLID.LSP
{
    /// <summary>
    /// Liskov Substitution Principle (LSP)
    /// Aynı temel sınıftan türeyen tüm sınıflar, birbirlerinin yerine kullanılabilir olmalıdır.
    /// Bu yer değiştirme durumunda, sınıfa özel bir istisna kesinlikle oluşmamalıdır.
    /// </summary>

    //BAD
    public interface IDevice
    {
        void Run();
        void Call();
    }
    public class Telephone : IDevice
    {
        public void Call()
        {
            Console.WriteLine("you can call");
        }

        public void Run()
        {
            Console.WriteLine("Device started");
        }
    }
    public class Laptop : IDevice
    {
        public void Call()
        {
            Console.WriteLine("you can call");
        }

        public void Run()
        {
            Console.WriteLine("Device started");
        }
    }
    public class Mp3Player : IDevice
    {
        public void Call()
        {
            throw new NotImplementedException(); //Lsp İhlali: Mp3 Çalar ile arama yapamazsın.
        }

        public void Run()
        {
            Console.WriteLine("Device started");
        }
    }

    //GOOD
    public interface Call
    {
        void Call();
    }
    public interface IGoodDevice
    {
        void Run();
    }
    public class GoodTelephone : IGoodDevice, Call
    {
        public void Call()
        {
            Console.WriteLine("you can call");
        }

        public void Run()
        {
            Console.WriteLine("Device started");
        }
    }
    public class GoodLaptop : IGoodDevice, Call
    {
        public void Call()
        {
            Console.WriteLine("you can call");
        }

        public void Run()
        {
            Console.WriteLine("Device started");
        }
    }
    public class GoodMp3Player : IGoodDevice
    {
        public void Run()
        {
            Console.WriteLine("Device started");
        }
    }
}
