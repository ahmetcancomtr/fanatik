using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using fanatik.interfaces;
using fanatik.models;
using fanatik.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fanatik.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> logger;
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(ILogger<AuthenticationController> logger,IAuthenticationService authenticationService)
        {
            this.logger = logger;
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("login")]
        public  async Task<TokenInfo> Login(AuthenticationRequest request)
        {
            return await authenticationService.GetToken(request);
        }        
    }
}


