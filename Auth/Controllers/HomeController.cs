using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    /// <summary>
    /// Home
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IAccountService accountService;
        public HomeController(IUserService userService, IRoleService roleService, IAccountService accountService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.accountService = accountService;
        }

        /// <summary>
        /// 基本请求
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> Get()
        {
           
            //var userList = new List<Entities.User>();
            //for (int i = 0; i < 10000; i++)
            //{
            //    userList.Add(new Entities.User()
            //    {
            //        Name = "测试数据:" + Guid.NewGuid().ToString(),
            //        Account = "测试账号:" + string.Format("{0:yyyy-MM-dd HH}", DateTime.Now),
            //        Password = "123",
            //    });
            //}
            //userService.AddRange(userList.ToArray());
            var users = await Task.Run(()=> 
            {
                return userService.QueryAll().ToList(); 
            });

            return users;
        }

    }
}