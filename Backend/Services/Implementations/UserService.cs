﻿using Merchanmusic.Data;
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

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public List<User> GetUsersWaitingValidation()
        {
            return _context.Users.Where(u => u.WaitingValidation == true).ToList();
        }

        public User GetUserById(string id) 
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public bool? HasDarkModeOn(string id)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user.DarkModeOn;
        }

        public string? GetRoleById(string id)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user?.Role;
        }

        public bool IsWaitingValidation(string id)
        {
            return _context.Users.Any(u => u.Id == id && u.WaitingValidation == true);
        }

        public bool HasPersonalInfo(string id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            var propertiesToCheck = new[] { "Address", "Apartment", "Country", "City", "Phone", "PostalCode" };

            foreach (var propertyName in propertiesToCheck)
            {
                var property = user.GetType().GetProperty(propertyName);
                if (property.GetValue(user) == null)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsUserDeleted(string id)
        {
            return _context.Users.Any(u => u.Id == id && u.State == false);
        }

        //public User? GetUserById(string id)
        //{
        //    return _context.Users.FirstOrDefault(u => u.Id == id);
        //}

        public bool CheckIfUserExists(string id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public void SetDarkMode(string id, bool darkMode)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            user.DarkModeOn = darkMode;
            _context.SaveChanges();
        }

        public void UpdateRole(string id, string role)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            user.Role = role;
            _context.Remove(user);
            _context.SaveChanges();
            _context.Add(user);

            _context.SaveChanges();
        }

        public string CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public void UpdateValidationStatus(string id, bool validationStatus)
        {
            User user = _context.Users.SingleOrDefault(u => u.Id == id);
            user.WaitingValidation = validationStatus;
            _context.Update(user);
            _context.SaveChanges();
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
