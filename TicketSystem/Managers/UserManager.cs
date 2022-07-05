using Microsoft.AspNetCore.Components;
using SQLDataAccess;
using SQLDataAccess.Models;
using TicketSystem.Models;

namespace TicketSystem.Managers
{
    public class UserManager
    {
        private readonly UserData UserDb;
        public UserManager(UserData userDb)
        {
            UserDb = userDb;
        }

        public Action loginChanged;
        public bool IsLoggedIn { get; set; }
        public UserModel? CurrentUser { get; set; }
       
        private List<UserModel> userModels = new List<UserModel>();

        public bool Login(DisplayUserLoginModel loginModel)
        {
            UserModel? user = (from UserModel in userModels
                              where UserModel.EmailAddress == loginModel.EmailAddress
                              select UserModel).FirstOrDefault();

            if(user == null) return false;

            if (Helpers.PasswordHash.VerifyPassword(loginModel.Password, user.PasswordHash))
            {
                IsLoggedIn = true;
                CurrentUser = user;
                loginChanged.Invoke();
                return true;
            }
            else return false;
        }

        public UserModel? GetUserById(int id)
        {
            return userModels.FirstOrDefault(x => x.Id == id);
        }

        public void Logout()
        {
            CurrentUser = null;
            IsLoggedIn = false;
            loginChanged.Invoke();
        }

        public async Task<bool> Register(DisplayUserRegisterModel registerModel)
        {
            if(!userModels.Exists(x => x.EmailAddress == registerModel.EmailAddress))
            {
                UserModel model = new UserModel()
                {
                    EmailAddress = registerModel.EmailAddress,
                    IsAdmin = false,
                    PasswordHash = Helpers.PasswordHash.HashPassword(registerModel.Password)
                };
                await UserDb.InsertUser(model);
                userModels = await UserDb.GetUsers();

                DisplayUserLoginModel login = new DisplayUserLoginModel()
                {
                    EmailAddress = registerModel.EmailAddress,
                    Password = registerModel.Password
                };
                Login(login);
                return true;
            }
            return false;
        }

        public async Task Initialize()
        {
            userModels = await UserDb.GetUsers();
        }
    }
}
