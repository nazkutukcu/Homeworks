using AutoMapper;
using Homework1.API.Models.DTOs;
using System.Xml.Linq;

namespace Homework1.API.Models
{
    public class UserService:IUserService
    {
        //service class handles business logic.

        //service class shouldnt directly interact with repository, it should interact through the interface => dependency injection
        private readonly IUserRepository userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
            userRepository = new UserRepository();
        }

        public List<UserDto> GetAll()
        {
            List<User> users = userRepository.GetAll();

            var userDtos = _mapper.Map<List<UserDto>>(users);

            return userDtos;
        }
        public ResponseDto<int> Save(UserSaveDtoRequest request)
        {
            
                var id = new Random().Next(1, 1000);

                var user = new User
                {
                    Id = id,
                    Name = request.Name,
                    Surname = request.Surname,
                    Age = request.Age!.Value,
                };
                userRepository.Save(user);

                return ResponseDto<int>.Success(id);
           
        }
        public void Delete(int id)
        {
            userRepository.Delete(id);
        }
        public void Update(UserUpdateDtoRequest request)
        {
            var user = new User()
            {
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                Age = request.Age,
            };
            userRepository.Update(user);
        }

        //bonus: This method performs a search operation, filtering users based on name and age range.
        public List<UserDto> Search(string name, int? minAge, int? maxAge)
        {
            var users = userRepository.GetAll();

            // Filtering users by name, ignoring case sensitivity,
            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(u => u.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            // Filtering by Age Range
            if (minAge.HasValue)
            {
                users = users.Where(u => u.Age >= minAge.Value).ToList();
            }

            if (maxAge.HasValue)
            {
                users = users.Where(u => u.Age <= maxAge.Value).ToList();
            }
         
            var result = _mapper.Map<List<UserDto>>(users);

            return result;
        }

        public UserDto GetById(int id)
        {
            var users = userRepository.GetAll();

            //filtering users list based on the id
            var user = users.FirstOrDefault(u => u.Id == id);

            return _mapper.Map<UserDto>(user);
        }
    }

}
