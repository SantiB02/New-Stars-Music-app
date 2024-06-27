using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;

public interface IUserService
{
    public User? GetUserByEmail(string email);
    public bool CheckIfUserExists(string userEmail);
    public void UpdateUser(User user);
    public void DeleteUser(int userId);
    public Task<List<User>> GetUsersByRole(int roleId);
        }
