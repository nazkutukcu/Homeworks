using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanCodeConsoleApp.Functions.Sample8
{
    /// <summary>
    /// Bu örnekte, "Learn to use setters and getters" prensibi, bir sınıfın özelliklerine (properties) erişimi 
    /// kontrol etmek ve bu erişimi düzenlemek için get ve set metodlarını kullanmayı önerir.
    /// </summary>

    //BAD
    public class BadStudent
    {
        public string FullName;

        public BadStudent(string name)
        {
            FullName = name;
        }
        public static void Main()
        {
            var student = new BadStudent("Naz Kütükçü");

            // Öğrenci adını değiştir
            student.FullName = "Burcu Budak";
        }
    }
    //GOOD
    public class GoodStudent
    {
        private string _fullName;

        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                // Özel kurallar veya doğrulamalar eklenebilir
                if (!string.IsNullOrEmpty(value))
                {
                    _fullName = value;
                }
            }
        }

        public GoodStudent(string name)
        {
            _fullName = name;
        }
        public static void Main()
        {
            var student = new GoodStudent("Naz Kütükçü");

            // Öğrenci adını değiştir
            student.FullName = "Burcu Budak";
        }
    }
}
