//using Merchanmusic.Data;
//using System.Data.Common;
//using System.Diagnostics.Eventing.Reader;

//namespace Merchanmusic.Services.Implementations
//{
//    public class UserService : IUserService
//    {
//        private readonly MerchContext _merchcontext;

//        public UserService(MerchContext merchcontext)
//        {
//            _context = context;
//        }

//    public User? GetUserByEmail (string email)
//         {
//            return _context.Users.SingleOrDefault (u =>u.Email == email);  

//          }
//     public bool CheckIfUserExists (string userEmail)
//       {
//        return _context.Users.Any (u=> u.Email  == userEmail); 
//       }

//       pubic BaseResponse ValidateUser ( string email, string password )
//       {
//            BaseResponse response = new();
//            User? userForlogin = _context.Users.SingleOrDefault(u => u.Email == email); 
//            if (userForlogin!=null)
//            {
//                if (userForlogin.Password == password)
//                {
//                    response.Result = true;
//                    response.Message = "succesful login";
//                }      
//                else
//                {
//                    response.Result = false;
//                    response.Message = "wrong password";
//                }
//                else
//                {
//                    response.Result = false;
//                    response.Message = "wrong password";                                  
//                }

//            }
//            else
//            {
//                response.Result = false;
//                response.Message = "wrong email";
//            }
//            return response;

//        }

//        public int CreateUser (User user)
//        {
//            _context.Add(user);
//            _context.SaveChanges();
//            return user.Id;
//        }

//        public UpdateUser (User user)
//        {
//            _context.Update(user);
//            _context.SaveChanges();
//            return Results.Updated;
//        }

//        public DeleteUser (int userId)
//        {
//          User userToBeDeleted = _context.Users.SingleOrDefault(u => u.Id == userId);
//           usertoBeDeleted.State = false;
//            _context.Update(userToBeDeleted);
//            _context.SaveChanges();
//            return Results.Deleted;
//        }
//         public List<User> GetUserByRole (string role)
//        {
//            return _context.Users.where (u => u.UserType == role).ToList();
//        }
//    }
//}