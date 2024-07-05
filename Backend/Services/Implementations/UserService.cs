using Merchanmusic.Data;
using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;
using Merchanmusic.Enums;
using Microsoft.EntityFrameworkCore;

namespace Merchanmusic.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly MerchContext _context;

        public UserService(MerchContext context)
        {
            _context = context;
        }

        public string? GetRoleById(string id)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user?.Role;
        }

        public bool IsUserDeleted(string id)
        {
            return _context.Users.Any(u => u.Id == id && u.State == false);
        }

        public User? GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool CheckIfUserExists(string id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public void EnsureUser(User userToEnsure)
        {
            User? user = this.GetUserById(userToEnsure.Id);
            if (user == null) // if the Auth0 user doesn't exist in our DB, we create it
            {
                this.CreateUser(userToEnsure);     
            }
        }

        public string CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public void UpdateUser(User user)
        {
            _context.ChangeTracker.Clear();
            _context.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            User userToBeDeleted = _context.Users.SingleOrDefault(u => u.Id == id);
            userToBeDeleted.State = false;
            _context.Update(userToBeDeleted);
            _context.SaveChanges();
        }
        public async Task<List<User>> GetUsersByRole(string roleName)
        {
            List<User> results = await _context.Users.Where(u => u.Role == roleName).ToListAsync();
            return results;
        

    }
    }
}
