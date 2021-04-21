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
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        //!!!!!!!!!!!!!!DİKKAT!!!!!!!!!!!!!!!!
        //ac Test Amaçlı Anonym erişime açık
        [HttpPost]
        [Route("adduser")]
        public  async Task AddUser(UserModel request)
        {
            await userService.AddUser(request);
        }        
    }
}


