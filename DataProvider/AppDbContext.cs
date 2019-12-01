#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-19 22:51:27
* Description: 数据库上下文对象
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-19 22:51:27
* ModifiedNote:
===================================================================*/
#endregion

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataProvider
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
