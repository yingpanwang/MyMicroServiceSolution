#region 接口信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-22 23:08:18
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-22 23:08:18
* ModifiedNote:
===================================================================*/
#endregion

using Entities;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServices
{
    public interface IRoleService : IBaseService<IRoleRepository, Role>
    {
    }
}
