using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;

public interface IUserService
{
    public User? GetUserByEmail(string email);
    public bool CheckIfUserExists(string userEmail);
    public BaseResponse ValidateUser(string email, string password);
    public int CreateUser(User user);
 //  public Updated UpdateUser(User user);
//   public Deleted DeleteUser(int userId);
    public List<User> GetUsersByRole(string role);
}
