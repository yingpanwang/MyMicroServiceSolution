using DataProvider;
using Entities;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.IdentityServer4.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext,ILogger<User> logger) : base(dbContext,logger)
        {
        }
        /// <summary>
        /// 用户账户查验(登录)
        /// </summary>
        /// <param name="account">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<User> CheckAsync(string account, string password)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == account && x.Password == password);
        }
    }
}