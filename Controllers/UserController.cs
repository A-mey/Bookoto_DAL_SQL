using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using DataAccess.Models;
using DataAccess.Services;

namespace DataAccess.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }

        //[HttpPost]
        //public DataSet CreateUser([FromBody] Pill Pill)
        //{
        //    UserService UserService = new UserService();
        //    DataSet ds = UserService.Register(Pill);
        //    return ds;
        //}

        [HttpPost]
        public DataSet Post([FromBody] Test Test)
        {
            UserService UserService = new UserService();
            DataSet ds = UserService.Test(Test);
            return ds;
        }
    }
}
