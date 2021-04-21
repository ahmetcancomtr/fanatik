using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fanatik.interfaces;
using fanatik.models;
using fanatik.extention;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using fanatik.data;

namespace fanatik.Controllers
{
    public class UserService : IUserService
    {
        private readonly ISettings settings;
        private readonly IUserRepo userRepo;

        public UserService(ISettings settings,IUserRepo userRepo)
        {
            this.settings = settings;
            this.userRepo = userRepo;
        }
        public async Task AddUser(UserModel userModel)
        {
            var userData=new UserEntity(){username=userModel.UserName,userid=userModel.UserName,passwordhash=userModel.Password.CalcMD5()};
            await userRepo.AddUser(userData);
        }
    }

}