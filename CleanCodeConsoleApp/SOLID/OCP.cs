using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.SOLID.OCP
{
    /// <summary>
    /// Open/Closed Principle (OCP): Bir class ya da method gelişime açık, değişime kapalı olmalıdır.
    /// Var olan kodları değiştirmeden, yeni class'lar yazarak uygulamanın davranışı değiştirilir.
    /// </summary>

    //BAD
    public class BadApplicationService
    {
        public List<string> GetApplicationTitle()
        {
            //Service class'ı BadApplicationRepository yani somut sınıfı biliyor.
            var applicationRepository = new BadApplicationRepository();
            return applicationRepository.GetApplicationTitle();
        }
    }
    public class BadApplicationRepository
    {
        public List<string> GetApplicationTitle()
        {
            return ["Backend Developer", "UX Designer", "Test Engineer"];
        }
    }

    //GOOD
    public interface IApplicationRepository
    {
        List<string> GetApplicationTitle();
    }
    public class GoodApplicationRepository: IApplicationRepository
    {
        public List<string> GetApplicationTitle()
        {
            return ["Backend Developer", "UX Designer", "Test Engineer"];
        }
    }
    public class GoodApplicationService
    {
        //Service class'ı soyut sınıfı interface'i biliyor.
        private IApplicationRepository _applicationRepository;
        public GoodApplicationService(IApplicationRepository repository)
        {
            _applicationRepository = repository;
        }
        public List<string> GetApplicationTitle()
        {
            return _applicationRepository.GetApplicationTitle();
        }

    }
    //Örneğin artık başka bir repository kullanmak istiyorsak mevcut kodu değiştirmeden, IApplicationRepository implemente etmemiz yeterli.
    public class DifferentApplicationRepository : IApplicationRepository
    {
        public List<string> GetApplicationTitle()
        {
            return new List<string> { "Data Scientist", "DevOps Engineer", "Security Analyst" };
        }
    }
    public class ApplicationController
    {
        //interface'i constructorda geçtik,productService kim kullanıcaksa(controller..) new'lerken içine IProductRepository geçmeli.
        public ApplicationController()
        {
            var applicationService = new GoodApplicationService(new GoodApplicationRepository());
            applicationService.GetApplicationTitle();
        }
        
    }
}
