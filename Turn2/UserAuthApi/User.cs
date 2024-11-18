namespace UserAuthApi
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public interface IUserRepository
    {
        User GetUserByUsername(string username);
    }

    public class UserRepository : IUserRepository
    {
        private readonly Dictionary<string, User> _users = new Dictionary<string, User>();

        public UserRepository()
        {
            _users.Add("user1", new User { Username = "user1", Password = "password1" });
            _users.Add("user2", new User { Username = "user2", Password = "password2" });
        }

        public User GetUserByUsername(string username)
        {
            return _users.TryGetValue(username, out User user) ? user : null;
        }
    }
}
