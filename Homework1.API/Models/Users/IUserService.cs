using Homework1.API.Models.DTOs;
namespace Homework1.API.Models.Users
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        ResponseDto<int> Save(UserSaveDtoRequest request);
        void Delete(int id);
        void Update(UserUpdateDtoRequest request);
        List<UserDto> Search(string keyword, int? minAge, int? maxAge);
        UserDto GetById(int id);
    }
}
