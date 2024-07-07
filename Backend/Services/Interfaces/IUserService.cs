using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;
using Microsoft.AspNetCore.Mvc;

public interface IUserService
{
    List<User> GetAllUsers();
    public string? GetRoleById(string id);
    public bool IsWaitingValidation(string id);
    public bool IsUserDeleted(string id);
    public User? GetUserById(string id);
    public bool CheckIfUserExists(string id);
    public string CreateUser(User user);
    public void UpdateValidationStatus(string id, bool validationStatus);
    public void UpdateUser(User user);
    public void DeleteUser(string id);
    public Task<List<User>> GetUsersByRole(string roleName);
}
