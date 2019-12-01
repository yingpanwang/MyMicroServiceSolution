#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-22 22:43:11
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-22 22:43:11
* ModifiedNote:
===================================================================*/
#endregion

using DataProvider;
using Entities;
using IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AccountRepository : BaseRepository<User>,IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext, ILogger<User> logger) : base(dbContext, logger)
        {
        }

        /// <summary>
        /// 是否存在指定账号
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns></returns>
        public bool ExistAccount(string account)
        {
            return this._dbSet.Any(x=>x.Account == account);
        }

        /// <summary>
        /// 查找账号用户信息
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>对应用户信息</returns>
        public async Task<User> FindAccountUser(string account, string password)
        {
           return await Task.Run<User>(() => 
            {
                return this._dbSet.FirstOrDefault(x => x.Account == account && x.Password == password);
            });
        }
    }
}
