using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonMogendorff
{
    public class UsersLogic : BaseLogic
    {

        public UserModel GetOneUser(int id) // Gets one user from the DB and returns it
        {
            return DB.UserInfoes.Where(u => u.UserID == id).Select(u => new UserModel
            {
                userId = u.UserID,
                userName = u.Username,
                bDay = u.BirthDate,
                email = u.Email,
                fullName = u.FullName,
                password = u.Password
            }).SingleOrDefault();
        }

        public List<UserModel> GetAllUsers() // Gets all users from the DB and returns them as a list
        {
            return DB.UserInfoes.Select(f => new UserModel
            {
                fullName = f.FullName,
                bDay = f.BirthDate,
                email = f.Email,
                password = f.Password,
                userId = f.UserID,
                userName = f.Username
            }).ToList();
        }

        public UserModel AddUser(UserModel userModel)
        {
            UserInfo user = new UserInfo
            {
                Username = userModel.userName,
                Password = userModel.password,
                BirthDate = userModel.bDay,
                FullName = userModel.fullName,
                Email = userModel.email
            };
            DB.UserInfoes.Add(user);
            DB.SaveChanges();

            userModel.userId = user.UserID;
            return GetOneUser((int)userModel.userId);
        }

        public UserModel GetUserByDetails(string username, string password) // Gets a user by the details.
        {
            return DB.UserInfoes.Where(u => u.Username.ToLower() == username.ToLower() && u.Password == password).Select(u => new UserModel
            {
                userId = u.UserID,
                userName = u.Username,
                bDay = u.BirthDate,
                email = u.Email,
                fullName = u.FullName,
                password = u.Password
            }).SingleOrDefault();
        }

    }
}
