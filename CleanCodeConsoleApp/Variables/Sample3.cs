using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Variables
{
    /// <summary>
    /// "Don't add unneeded context" prensibi, bir değişkenin veya özelliğin isminin, zaten içinde bulunduğu 
    /// sınıf veya nesne tarafından sağlanan bağlamı tekrarlamamasını önerir. 
    /// 
    /// Yani, eğer bir sınıfın adı veya bir nesnenin adı zaten bir şeyi belirtiyorsa, bu belirtimi tekrar etmekten
    /// kaçınılmalıdır.
    /// </summary>

    // BAD
    public class Employee
    {
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeDepartment { get; set; }

        //...
    }

    // GOOD
    public class Employee2
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Department { get; set; }

        //...
    }
}
