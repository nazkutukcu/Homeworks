using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    /// Yan Etkilerden Kaçının (Avoid Side Effects) prensibi,bir fonksiyonun sadece girdi alması,
    /// bir değeri hesaplaması ve çıktı vermesi gerektiğini savunur.
    /// Yan etkiler, bir fonksiyonun dışındaki bir durumu değiştirmesi veya başka bir şeyi etkilemesi anlamına gelir.
    /// </summary>
    /// 
    //BAD
    public class BadSideEffectExample
    {
        //CapitalizeName metodu, global bir değişkeni değiştiriyor.
        //Bu, fonksiyonun dışındaki bir durumu etkileyen bir yan etki oluşturuyor. 

        private static string name = "Naz Kütükçü";

        public static void CapitalizeName()
        {
            name = name.ToUpper();
        }

        public static void Main()
        {
            CapitalizeName();

            Console.WriteLine(name); // 'NAZ KÜTÜKÇÜ'
        }
    }

    //GOOD
    public class GoodSideEffectExample
    {
        //Bu iyi örnekte, CapitalizeName metodu dışındaki hiçbir durumu değiştirmiyor.
        //Sadece girdi alıyor, işlem yapıyor ve çıktıyı döndürüyor.
        public static string CapitalizeName(string inputName)
        {
            return inputName.ToUpper();
        }

        public static void Main()
        {
            string originalName = "John Doe";
            string newName = CapitalizeName(originalName);

            Console.WriteLine(originalName); // 'Naz Kütükçü'
            Console.WriteLine(newName);      // 'NAZ KÜTÜKÇÜ'
        }
    }


}
