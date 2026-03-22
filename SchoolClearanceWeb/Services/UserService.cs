// Services/UserService.cs
using SchoolClearanceWeb.Model;

public class UserService
{
    private readonly List<UserAccountModel> _users = new();

    public bool Register(string firstName, string lastName, string username, string password)
    {
        if (_users.Any(u => u.Username == username))
            return false; // username already taken

        _users.Add(new UserAccountModel { FirstName = firstName, LastName = lastName, Username = username, Password = password });
        return true;
    }

    public UserAccountModel? Login(string username, string password)
        => _users.FirstOrDefault(u => u.Username == username && u.Password == password);
}
