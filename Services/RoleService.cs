#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-22 23:06:02
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-22 23:06:02
* ModifiedNote:
===================================================================*/
#endregion

using Entities;
using IRepositories;
using IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class RoleService : BaseService<IRoleRepository, Role>,IRoleService
    {
        public RoleService(IRoleRepository repository) : base(repository)
        {
        }
    }
}
