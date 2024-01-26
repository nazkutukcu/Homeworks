using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Variables
{
    /// <summary>
    /// "Avoid nesting too deeply and return early" prensibi, derin iç içe geçmiş if-else ifadelerinden kaçınılmasını
    /// ve erken dönüş yapılmasını önerir.
    /// </summary>
    public class TemperatureChecker
    {
        //BAD
        public string GetTemperatureStatusBad(int temperature)
        {
            string status = "";

            if (temperature > 30)
            {
                if (temperature > 40)
                {
                    status = "Very Hot";
                }
                else
                {
                    status = "Hot";
                }
            }
            else
            {
                if (temperature < 10)
                {
                    status = "Very Cold";
                }
                else
                {
                    status = "Cold";
                }
            }

            return status;
        }

        //GOOD
        public string GetTemperatureStatusGood(int temperature)
        {
            if (temperature > 40)
            {
                return "Very Hot";
            }

            if (temperature > 30)
            {
                return "Hot";
            }

            if (temperature < 10)
            {
                return "Very Cold";
            }

            return "Cold";
        }
    }
}
