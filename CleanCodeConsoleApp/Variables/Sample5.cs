using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Variables
{
    /// <summary>
    ///  "Use the same vocabulary for the same type of variable" prensibi, aynı türdeki değişkenler için aynı kelime
    ///  dağarcığını kullanmayı önerir. Bu, kodun tutarlı ve anlaşılır olmasına yardımcı olur.
    /// </summary>

    public class DataProcessor
    {
        //BAD
        public void FetchCustomerData()
        {
            // Müşteri verilerini getirme işlemleri...
        }

        public void RetrieveClientInformation()
        {
            // İstemci bilgilerini almak için işlemler...
        }

        public void GetUserDetails()
        {
            // Kullanıcı detaylarını alma işlemleri...
        }

        public void LoadMemberProfile()
        {
            // Üye profillerini yükleme işlemleri...
        }

        // GOOD
        public void GetCustomer()
        {
            // Müşteri verilerini getirme işlemleri...
        }

        public void GetClient()
        {
            // İstemci bilgilerini alma işlemleri...
        }

        public void GetUser()
        {
            // Kullanıcı detaylarını alma işlemleri...
        }

        public void GetMember()
        {
            // Üye profillerini yükleme işlemleri...
        }
    }



}
