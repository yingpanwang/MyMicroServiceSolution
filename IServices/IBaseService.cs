#region 接口信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-21 23:11:37
* Description: 基础Service功能接口
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-21 23:11:37
* ModifiedNote:
===================================================================*/
#endregion

using IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace IServices
{
    public interface IBaseService<TRepository, TEntity> 
        where TEntity : class ,new()
        where TRepository : class,IBaseRepository<TEntity>
    {
        bool Add(TEntity entity);
        bool AddRange(params TEntity[] entity);
        bool Delete(TEntity entity);

        bool Update(TEntity entity);

        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <returns>符合条件的实体集合</returns>
        IEnumerable<TEntity> QueryAll();
    }
}
