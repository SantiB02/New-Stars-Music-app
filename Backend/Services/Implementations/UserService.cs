using Merchanmusic.Data;
using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;

namespace Merchanmusic.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly MerchContext _context;

        public UserService(MerchContext context)
        {
            _context = context;
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);

        }
        public bool CheckIfUserExists(string userEmail)
        {
            return _context.Users.Any(u => u.Email == userEmail);
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            User userToBeDeleted = _context.Users.SingleOrDefault(u => u.Id == userId);
            userToBeDeleted.State = false;
            _context.Update(userToBeDeleted);
            _context.SaveChanges();
        }
        public async Task<List<User>> GetUsersByRole(int roleId)
        {
            List<User> results = await _context.Users.Where(u => u.UserRoleId == roleId).ToListAsync();
            return results;
        

    }
    }
}
