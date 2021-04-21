using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fanatik.models;

namespace fanatik.interfaces
{
    public interface IAuthenticationService
    {
       Task<TokenInfo> GetToken(AuthenticationRequest request);

    }

}