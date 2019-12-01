#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-22 22:57:03
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-22 22:57:03
* ModifiedNote:
===================================================================*/
#endregion

using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataProvider
{
    public partial class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
