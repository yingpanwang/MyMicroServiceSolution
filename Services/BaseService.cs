#region 类信息
/*=================================================================
* Author: 王盈攀
* CreatedTime: 2019-9-21 23:18:05
* Description: <功能描述>
*
* Modified By : <更新人>
* ModifiedTime: 2019-9-21 23:18:05
* ModifiedNote:
===================================================================*/
#endregion

using IRepositories;
using IServices;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    /// <summary>
    /// 基础服务类
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    public class BaseService<TRepository, TEntity> : IBaseService<TRepository, TEntity> 
        where TEntity:class,new()
        where TRepository : class,IBaseRepository<TEntity>
    {
        /// <summary>
        /// 基础服务仓储依赖
        /// </summary>
        /// <param name="repository"></param>
        public BaseService(TRepository repository)
        {
            this.Repository = repository;
        }
        /// <summary>
        /// 基础服务仓储依赖
        /// </summary>
        /// <param name="repository"></param>
        public BaseService(TRepository repository, UnitOfWork unitOfWork)
        {
            this.Repository = repository;
            this.UnitOfWork = unitOfWork;
        }
        /// <summary>
        /// 仓储
        /// </summary>
        protected TRepository Repository { get; set; }

        protected UnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(TEntity entity)
        {
            return this.Repository.Add(entity);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddRange(params TEntity []entity)
        {
            return this.Repository.AddRange(entity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(TEntity entity)
        {
            return this.Repository.Delete(entity);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(TEntity entity)
        {
            return false;
        }

        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <returns>符合条件的实体集合</returns>
        public IEnumerable<TEntity> QueryAll()
        {
            return this.Repository.QueryAll();
        }
    }

}
