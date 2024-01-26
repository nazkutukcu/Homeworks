using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    /// "Don’t use magic chains" prensibi, kod içinde belirli değerleri doğrudan kullanmak yerine, bu değerleri
    /// tanımlanan sabitler aracılığıyla kullanmayı önerir. Bu sayede, kodun okunabilirliği artar ve değerlerin
    /// değişmesi durumunda tüm kodu güncellemek daha kolay hale gelir.
    /// </summary>

    //BAD
    public class BadMagicChains
    {
        public void ProcessOrder(string status)
        {
            if (status == "Pending")
            {
                // işlemler...
            }
            else if (status == "Shipped")
            {
                // işlemler...
            }
            else if (status == "Delivered")
            {
                // işlemler...
            }
        }
    }

    //GOOD
    public class GoodMagicChains
    {
        // Sabitler kullanarak magic strings'leri tanımladık
        private const string PENDING_STATUS = "Pending";
        private const string SHIPPED_STATUS = "Shipped";
        private const string DELIVERED_STATUS = "Delivered";

        public void ProcessOrder(string status)
        {
            // Tanımlanan sabitleri kullanarak kontrolü gerçekleştirdik
            if (status == PENDING_STATUS)
            {
                // işlemler...
            }
            else if (status == SHIPPED_STATUS)
            {
                // işlemler...
            }
            else if (status == DELIVERED_STATUS)
            {
                // işlemler...
            }
        }
    }
}
