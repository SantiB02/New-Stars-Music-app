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

        public User? GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool CheckIfUserExists(string id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public bool EnsureUser(User userToEnsure)
        {
            bool isEnsured = false;
            User? user = this.GetUserById(userToEnsure.Id);
            if (user == null) // if the Auth0 user doesn't exist in our DB, we create it
            {
                switch (userToEnsure.Role)
                {
                    case nameof(UserRoleEnum.Client):
                        Client newClient = new()
                        {
                            Id = userToEnsure.Id,
                            Email = userToEnsure.Email,
                            Address = userToEnsure.Address,
                        };
                        this.CreateUser(newClient);
                        isEnsured = true;
                        break;
                    case nameof(UserRoleEnum.Seller):
                        Seller newSeller = new()
                        {
                            Id = userToEnsure.Id,
                            Email = userToEnsure.Email,
                            Address = userToEnsure.Address,
                        };
                        this.CreateUser(newSeller);
                        isEnsured = true;
                        break;
                }
            } else
            {
                if (userToEnsure.Role != user.Role) // if the Auth0 user has changed their role, we also change it in our DB
                {
                    user.Role = userToEnsure.Role;
                    this.UpdateUser(userToEnsure);
                }
                isEnsured = true;
            }
            
        return isEnsured;
        }

        public string CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public void UpdateUser(User user)
        {
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
