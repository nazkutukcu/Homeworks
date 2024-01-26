using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    /// "Remove dead code" prensibi kullanılmayan kodun (dead code) kod tabanında tutulmamasını,
    ///  gereksiz karmaşıklığı önlemek için kullanılır. 
    ///  
    ///  Eğer bir fonksiyon, metod veya sınıf hiçbir yerde çağrılmıyorsa, o kod öğesi artık gereksizdir ve
    ///  temizlenmelidir. Temizlenmeyen kullanılmayan kodlar, kod tabanının anlaşılmasını zorlaştırır ve
    ///  bakım maliyetini artırır.
    /// </summary>

    //BAD
    public class BadDataProcessor
    {
        public void OldProcessData(string url)
        {
            // ...
        }

        public void NewProcessData(string url)
        {
            // ...
        }
    }
    //GOOD
    public class GoodDataProcessor
    {
        public void ProcessData(string url)
        {
            // ...
        }
    }
}
