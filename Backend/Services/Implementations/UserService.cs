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

        public int GetUserRoleId(string roleName)
        {
            int roleId = roleName.Trim() switch
            {
                nameof(UserRoleEnum.Client) => (int)UserRoleEnum.Client,
                nameof(UserRoleEnum.Seller) => (int)UserRoleEnum.Seller,
                nameof(UserRoleEnum.Admin) => (int)UserRoleEnum.Admin,
                _ => (int)UserRoleEnum.Client,
            };
            return roleId;
        }

        public User? GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public string GetUserRole(string id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user.UserRole.RoleName;
        }

        public bool CheckIfUserExists(string id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public bool EnsureUser(UserPostDto userPostDto, string subClaim)
        {
            bool isEnsured = false;
            if (subClaim == userPostDto.Sub) //to validate that the new user in DB will mirror the Auth0 authenticated user
            {
                bool userExists = this.CheckIfUserExists(userPostDto.Sub);
                if (!userExists)
                {
                    switch (userPostDto.Role.Trim())
                    {
                        case nameof(UserRoleEnum.Client):
                            this.CreateClient(userPostDto);
                            isEnsured = true;
                            break;
                        case nameof(UserRoleEnum.Seller):
                            this.CreateSeller(userPostDto);
                            isEnsured = true;
                            break;
                    }
                }
            }
            return isEnsured;
        }

        public string CreateClient(UserPostDto userPostDto)
        {
            Client newClient = new()
            {
                Id = userPostDto.Sub,
                Email = userPostDto.Email,
                UserRoleId = this.GetUserRoleId(userPostDto.Role)
            };
            _context.Add(newClient);
            _context.SaveChanges();
            return newClient.Id;
        }

        public string CreateSeller(UserPostDto userPostDto)
        {
            Seller newSeller = new()
            {
                Id = userPostDto.Sub,
                Email = userPostDto.Email,
                UserRoleId = this.GetUserRoleId(userPostDto.Role)
            };
            _context.Add(newSeller);
            _context.SaveChanges();
            return newSeller.Id;
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
            int roleId = this.GetUserRoleId(roleName);
            List<User> results = await _context.Users.Where(u => u.UserRoleId == roleId).ToListAsync();
            return results;
        

    }
    }
}
