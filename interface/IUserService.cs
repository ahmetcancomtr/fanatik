using System;
using System.Threading.Tasks;
using fanatik.models;

namespace fanatik.interfaces
{
    public interface IUserService
    {
        Task AddUser(UserModel userModel);
    }

}