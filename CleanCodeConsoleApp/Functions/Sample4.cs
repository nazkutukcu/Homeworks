using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    ///  Use private/protected members prensibi, bir sınıftaki üyelerin (property, method vb.) erişim
    ///  belirleyicilerinin uygun şekilde kullanılmasını önerir. 
    ///  
    ///  Eğer bir özellik veya metodun sadece sınıf içinde değiştirilmesi veya erişilmesi gerekiyorsa,
    ///  bu üyelerin private veya protected olarak belirlenmesi gerektiğini ifade eder.
    /// </summary>

    //BAD
    class BadCar
    {
        // Brand public setter'a sahip,bu da başka bir yerden Brand özelliğin değerini değiştirmeyi mümkün kılıyor.
        public string Brand { get; set; }
        public BadCar(string brand)
        {
            Brand = brand;
        }
    }
    //GOOD
    class GoodCar
    {
        // Brand özelliği yalnızca public bir getter'a sahiptir.
        // private bir setter kullanılarak bu özelliğin sadece sınıf içinde değiştirilebilir ve dışarıdan müdahaleye kapalı olmasını sağlanabilir.
        public string Brand { get; }

        public GoodCar(string brand)
        {
            Brand = brand;
        }
    }
}
