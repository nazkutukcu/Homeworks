namespace Homework1.API.Models.Users
{
    public interface IUserRepository
    {
        //interfaces are contracts
        //interfaces define method signatures(return type + parameters that method have)
        List<User> GetAll();
        User Save(User user);
        void Update(User user);
        void Delete(int id);

    }
}
