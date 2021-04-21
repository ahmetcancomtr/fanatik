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
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepo authenticationRepo;
        private readonly ISettings settings;

        public AuthenticationService(IUserRepo authenticationRepo,ISettings settings)
        {
            this.authenticationRepo = authenticationRepo;
            this.settings = settings;
        }
        protected string createToken(UserEntity userDto)
        {
              // Creates the signed JWT
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.getSecretKey()));
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDto.userid)
                }),
                Expires =DateTime.UtcNow.Add(settings.getTokenExperationTime()),// DateTime.UtcNow.AddYears(2),
                //Issuer = "MyWebsite.com",
                //Audience = "MyWebsite.com",
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);
            
            return accessToken;
        }
        public async Task<TokenInfo> GetToken(AuthenticationRequest request)
        {
            var userDTO=await authenticationRepo.GetUser(request.userid);
            if(userDTO.passwordhash==request.password.CalcMD5())
            {
                var token= createToken(userDTO);
                return new TokenInfo(){token=token,Status=0};
            }
            return new TokenInfo(){Status=1};
        }
    }

}