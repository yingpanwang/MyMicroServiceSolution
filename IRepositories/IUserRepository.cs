using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// 用户账户查验(登录)
        /// </summary>
        /// <param name="account">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task<User> CheckAsync(string account,string password);
    }
}