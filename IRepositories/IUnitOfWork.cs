#region 接口信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-23 12:49:40
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-23 12:49:40
* ModifiedNote:
===================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace IRepositories
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交更改
        /// </summary>
        /// <returns></returns>
        int Commit();

    }
}
