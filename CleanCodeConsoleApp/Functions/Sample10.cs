using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    ///  "Avoid negative conditionals" prensibi, olumsuz ifadelerin (negative conditionals) kullanılmasından 
    ///  kaçınılmasını önerir.
    ///  
    /// Yani, kodun içinde "not", "non", "un-", "in-", "dis-" gibi olumsuz ifadelerle başlayan koşullu ifadelerin 
    /// yerine, olumlu ifadelerin kullanılması tavsiye edilir.
    /// </summary>
    
    public class NumberValidator
    {
        // BAD
        public bool IsNotNegative(int number)
        {
            return number >= 0;
        }

        public void BadProcessNumber(int number)
        {
            if (!IsNotNegative(number))
            {
                // Negative number handling...
            }
            else
            {
                // Positive number handling...
            }
        }

        // GOOD
        public bool IsPositive(int number)
        {
            return number > 0;
        }

        public void GoodProcessNumber(int number)
        {
            if (IsPositive(number))
            {
                // Positive number handling...
            }
            else
            {
                // Non-positive number handling...
            }
        }
    }

}
