#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-21 23:35:59
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-21 23:35:59
* ModifiedNote:
===================================================================*/
#endregion

using Entities;
using IRepositories;
using IServices;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class UserService : BaseService<IUserRepository, User>, IUserService
    {
        public UserService(IUserRepository repository, UnitOfWork unitOfWork) : base(repository, unitOfWork)
        {

        }
    }
}
