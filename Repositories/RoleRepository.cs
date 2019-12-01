#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-22 23:05:19
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-22 23:05:19
* ModifiedNote:
===================================================================*/
#endregion

using DataProvider;
using Entities;
using IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class RoleRepository : BaseRepository<Role>,IRoleRepository
    {
        public RoleRepository(AppDbContext dbContext, ILogger<Role> logger) : base(dbContext, logger)
        {
        }
    }
}
