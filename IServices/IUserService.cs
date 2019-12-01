#region 接口信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-21 23:53:44
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-21 23:53:44
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
    public interface IUserService:IBaseService<IUserRepository,User>
    {
    }
}
