using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.SOLID.DIP
{
    /// <summary>
    /// Dependency Inversion Principle (DIP): High level modüller, low level modüllere bağlı olmasın;
    /// bağlılık abstraction(soyutlama=>interface) üzerinden gerçekleşecek.
    /// 
    /// Inversion of Control Principle: Bir class(high level) başka bir class'a(low level) ihtiyaç duyuyorsa,
    /// constructor'ında enjekte edicek yani dışarıdan alıcak.
    /// 
    /// soyutlama => düşük coupling => clean code
    /// </summary>

    //BAD

    //low level class
    public class BadUserRepository
    {
        public void Add()
        {
            //add
        }
    }
    //high level class
    public class BadUserService
    {
        //high level class, low level(somut class) direkt biliyor.
        private readonly BadUserRepository _userRepository;          
        public BadUserService()
        {
            _userRepository = new BadUserRepository();
        }
        public void Add()
        {
            _userRepository.Add();
        }
    }

    //GOOD

    public class UserRepository: IUserRepository
    {
        public void Add()
        {
            //add
        }
    }
    public class UserRepositoryWithOracle : IUserRepository
    {
        public void Add()
        {
            //add
        }
    }

    // Abstraction (Interface)
    public interface IUserRepository
    {
        void Add();
    }
    public class UserService
    {
        private readonly IUserRepository _userRepository; //dependency inversion principle

        // inversion of control principle(Constructor injection)
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Add()
        {
            _userRepository.Add();
        }
    }

}
