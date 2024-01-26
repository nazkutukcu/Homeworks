using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Variables
{
    /// <summary>
    ///  "Use meaningful and pronounceable variable names" prensibi, değişken isimlerinin anlamlı ve telaffuz
    ///  edilebilir olması gerektiğini savunur. 
    ///  
    /// İsimler, kodun anlaşılabilirliğini artırır ve diğer geliştiricilerin veya bakım ekibinin kodu daha iyi 
    /// anlamasına yardımcı olur.
    /// </summary>

    public class Variables
    {
        //BAD
        int x = 5;
        string ymdstr = DateTime.UtcNow.ToString("MMMM dd, yyyy");

        //GOOD
        int userAge = 5;
        string formattedCurrentDate = DateTime.UtcNow.ToString("MMMM dd, yyyy");

    }


}
