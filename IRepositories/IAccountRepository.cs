#region 接口信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-22 22:40:53
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-22 22:40:53
* ModifiedNote:
===================================================================*/
#endregion

using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IAccountRepository:IBaseRepository<User>
    {
        /// <summary>
        /// 是否存在该账号
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns>是否存在</returns>
        bool ExistAccount(string account);

        /// <summary>
        /// 查找账号用户信息
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>对应用户信息</returns>
        Task<User> FindAccountUser(string account, string password);
    }
}
