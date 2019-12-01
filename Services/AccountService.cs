#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-24 21:41:37
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-24 21:41:37
* ModifiedNote:
===================================================================*/
#endregion

using DTO;
using Entities;
using IRepositories;
using IServices;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : BaseService<IAccountRepository, User>, IAccountService
    {
        public AccountService(IAccountRepository repository, UnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        /// <summary>
        /// 查找账号是否存在
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns></returns>
        public bool ExistAccount(string account)
        {
            return Repository.ExistAccount(account);
        }
    }
}
