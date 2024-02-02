namespace Homework1.API.Models.Users
{
    public class UserRepository : IUserRepository
    {
        // In-memory data for users storage
        private static readonly List<User> Users = new();

        public UserRepository()
        {
            //Adding sample data (If the user list is empty)
            if (Users.Count == 0)
            {
                Users.Add(new User { Id = 1, Name = "Deniz", Surname = "Alsancak", Age = 18 });
                Users.Add(new User { Id = 2, Name = "Emir ", Surname = "Danışman", Age = 35 });
                Users.Add(new User { Id = 3, Name = "Açılay", Surname = "Tan", Age = 41 });
                Users.Add(new User { Id = 4, Name = "Burak", Surname = "Çakaler", Age = 36 });
                Users.Add(new User { Id = 5, Name = "Burcu", Surname = "Budak", Age = 24 });
                Users.Add(new User { Id = 6, Name = "Gizem", Surname = "Efe", Age = 61 });
            }
        }
        public List<User> GetAll()
        {
            //Returns the users list.
            return Users;
        }
        public User Save(User user)
        {
            //Add a new user to the list.
            Users.Add(user);
            return user;
        }
        public void Update(User user)
        {
            //Updates the users info based on the provided user's id.
            var userToUpdateIndex = Users.FindIndex(p => p.Id == user.Id);

            Users[userToUpdateIndex].Name = user.Name;
            Users[userToUpdateIndex].Surname = user.Surname;
            Users[userToUpdateIndex].Age = user.Age;
        }
        public void Delete(int id)
        {
            //Removes the user from the list based on the provided user's id.
            var userToDeleteIndex = Users.FindIndex(_ => _.Id == id);

            Users.RemoveAt(userToDeleteIndex);
        }
    }
}
