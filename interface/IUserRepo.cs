using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fanatik.data;

namespace fanatik.interfaces
{
    public interface IUserRepo
    {
        Task<UserEntity> GetUser(string userid);
        Task<bool> AddUser(UserEntity userEntity);
    }

}