using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;
using Microsoft.AspNetCore.Mvc;

public interface IUserService
{
    public int GetUserRoleId(string roleName);
    public string GetUserRole(string id);
    public User? GetUserById(string id);
    public bool CheckIfUserExists(string id);
    public bool EnsureUser(UserPostDto userPostDto, string subClaim);
    public void UpdateUser(User user);
    public void DeleteUser(string id);
    public Task<List<User>> GetUsersByRole(string roleName);
}
