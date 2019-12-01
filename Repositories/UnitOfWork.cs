#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-23 21:04:14
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-23 21:04:14
* ModifiedNote:
===================================================================*/
#endregion

using DataProvider;
using IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class UnitOfWork :AppDbContext, IUnitOfWork
    {
        public UnitOfWork(DbContextOptions options) : base(options)
        {
        }

        public int Commit()
        {
            return this.SaveChanges();
        }

    }
}
