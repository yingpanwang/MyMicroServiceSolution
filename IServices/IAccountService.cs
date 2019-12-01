#region 接口信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-24 21:40:50
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-24 21:40:50
* ModifiedNote:
===================================================================*/
#endregion

using DTO;
using Entities;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAccountService:IBaseService<IAccountRepository,User>
    {
        /// <summary>
        /// 是否存在该账号
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        bool ExistAccount(string account);
        

    }
}
