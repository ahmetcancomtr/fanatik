
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fanatik.interfaces;
using fanatik.extention;
using fanatik.data;
using MongoDB.Driver;

namespace fanatik.repositories
{
     public class  UserRepo:RepoBase,IUserRepo
    {
        private readonly ISettings settings;

        public UserRepo(ISettings settings):base(settings)
        {
            this.settings = settings;
        }

        public async Task<bool> AddUser(UserEntity userEntity)
        {

            var db=GetDatabase();
            var usersColleciton=db.GetCollection<UserEntity>("users");
            await usersColleciton.InsertOneAsync(userEntity);
            
            return true;

        }

        public async Task<UserEntity> GetUser(string userid)
        {
            /*
            var userDTO=new UserEntity();
            userDTO.userid="ahmetcan";
            userDTO.username="ahmetcan";
            userDTO.passwordhash="1".CalcMD5();
            */
            var db=GetDatabase();
            var usersColleciton=db.GetCollection<UserEntity>("users");
            var UserEntity=await usersColleciton.FindSync(item=>item.userid==userid).FirstAsync();
            return UserEntity;
        }


    }

}