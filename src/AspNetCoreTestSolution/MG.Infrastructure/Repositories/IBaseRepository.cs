using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MG.Infrastructure.Core;
using MG.Infrastructure.WebControls;

namespace MG.Infrastructure.Repositories
{
    /// <summary>
    /// 仓储数据访问基接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        #region 单模型 CRUD 操作

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        bool Save(T entity, bool isCommit = true);

        /// <summary>
        /// 增加一条记录（异步方式）
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        Task<bool> SaveAsync(T entity, bool isCommit = true);

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        bool Update(T entity, bool isCommit = true);

        /// <summary>
        /// 更新一条记录（异步方式）
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T entity, bool isCommit = true);

        /// <summary>
        /// 增加或更新一条记录
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isSave">是否增加</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        bool SaveOrUpdate(T entity, bool isSave, bool isCommit = true);

        /// <summary>
        /// 增加或更新一条记录（异步方式）
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isSave">是否增加</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        Task<bool> SaveOrUpdateAsync(T entity, bool isSave, bool isCommit = true);

        /// <summary>
        /// 通过Lamda表达式获取实体
        /// </summary>
        /// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 通过Lamda表达式获取实体
        /// </summary>
        /// <param name="key">主键编号</param>
        /// <returns></returns>
        T Get(object key);

        /// <summary>
        /// 通过Lamda表达式获取实体（异步方式）
        /// </summary>
        /// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
        /// <returns></returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 通过Lamda表达式获取实体（异步方式）
        /// </summary>
        /// <param name="key">主键编号</param>
        /// <returns></returns>
        Task<T> GetAsync(object key);

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        bool Delete(T entity, bool isCommit = true);

        /// <summary>
        /// 删除一条记录（异步方式）
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(T entity, bool isCommit = true);

        #endregion

        #region 多模型 操作

        /// <summary>
        /// 增加多条记录，同一模型
        /// </summary>
        /// <param name="entities">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        bool SaveList(List<T> entities, bool isCommit = true);

        /// <summary>
        /// 增加多条记录，同一模型（异步方式）
        /// </summary>
        /// <param name="entities">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        Task<bool> SaveListAsync(List<T> entities, bool isCommit = true);

        /// <summary>
        /// 增加多条记录，独立模型
        /// </summary>
        /// <param name="entities">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        bool SaveList<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class;

        /// <summary>
        /// 增加多条记录，独立模型（异步方式）
        /// </summary>
        /// <param name="entities">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        Task<bool> SaveListAsync<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class;

        /// <summary>
        /// 更新多条记录，同一模型
        /// </summary>
        /// <param name="entities">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        bool UpdateList(List<T> entities, bool isCommit = true);

        /// <summary>
        /// 更新多条记录，同一模型（异步方式）
        /// </summary>
        /// <param name="entities">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        Task<bool> UpdateListAsync(List<T> entities, bool isCommit = true);

        /// <summary>
        /// 更新多条记录，独立模型
        /// </summary>
        /// <param name="entities">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        bool UpdateList<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class;

        /// <summary>
        /// 更新多条记录，独立模型（异步方式）
        /// </summary>
        /// <param name="T1">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        Task<bool> UpdateListAsync<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class;

        /// <summary>
        /// 删除多条记录，同一模型
        /// </summary>
        /// <param name="entities">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        bool DeleteList(List<T> entities, bool isCommit = true);

        /// <summary>
        /// 删除多条记录，同一模型（异步方式）
        /// </summary>
        /// <param name="entities">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        Task<bool> DeleteListAsync(List<T> entities, bool isCommit = true);

        /// <summary>
        /// 删除多条记录，独立模型
        /// </summary>
        /// <param name="entities">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        bool DeleteList<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class;

        /// <summary>
        /// 删除多条记录，独立模型（异步方式）
        /// </summary>
        /// <param name="entities">实体模型集合</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        Task<bool> DeleteListAsync<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class;

        /// <summary>
        /// 通过Lamda表达式，删除一条或多条记录
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        bool Delete(Expression<Func<T, bool>> predicate, bool isCommit = true);

        /// <summary>
        /// 通过Lamda表达式，删除一条或多条记录（异步方式）
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, bool isCommit = true);

        #endregion

        #region 获取多条数据操作

        IQueryable<T> Entities { get; }

        /// <summary>
        /// 返回IQueryable集合，延时加载数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> LoadAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 返回IQueryable集合，延时加载数据（异步方式）
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IQueryable<T>> LoadAllAsync(Expression<Func<T, bool>> predicate);

        // <summary>
        /// 返回List<T>集合,不采用延时加载
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<T> LoadListAll(Expression<Func<T, bool>> predicate);

        // <summary>
        /// 返回List<T>集合,不采用延时加载（异步方式）
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<T>> LoadListAllAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// T-Sql方式：返回IQueryable<T>集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="para">Parameters参数</param>
        /// <returns></returns>
        IQueryable<T> LoadAllBySql(string sql, params DbParameter[] para);

        /// <summary>
        /// T-Sql方式：返回IQueryable<T>集合（异步方式）
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="para">Parameters参数</param>
        /// <returns></returns>
        Task<IQueryable<T>> LoadAllBySqlAsync(string sql, params DbParameter[] para);

        /// <summary>
        /// T-Sql方式：返回List<T>集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="para">Parameters参数</param>
        /// <returns></returns>
        List<T> LoadListAllBySql(string sql, params DbParameter[] para);

        /// <summary>
        /// T-Sql方式：返回List<T>集合（异步方式）
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="para">Parameters参数</param>
        /// <returns></returns>
        Task<List<T>> LoadListAllBySqlAsync(string sql, params DbParameter[] para);

        /// <summary>
        /// 可指定返回结果、排序、查询条件的通用查询方法，返回实体对象集合
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <typeparam name="TResult">数据结果，与TEntity一致</typeparam>
        /// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">返回结果（必须是模型中存在的字段）</param>
        /// <param name="isAsc">排序方向，true为正序false为倒序</param>
        /// <returns>实体集合</returns>
        List<TResult> QueryEntity<TEntity, TOrderBy, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool isAsc)
            where TEntity : class
            where TResult : class;

        /// <summary>
        /// 可指定返回结果、排序、查询条件的通用查询方法，返回实体对象集合（异步方式）
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <typeparam name="TResult">数据结果，与TEntity一致</typeparam>
        /// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">返回结果（必须是模型中存在的字段）</param>
        /// <param name="isAsc">排序方向，true为正序false为倒序</param>
        /// <returns>实体集合</returns>
        Task<List<TResult>> QueryEntityAsync<TEntity, TOrderBy, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool isAsc)
            where TEntity : class
            where TResult : class;

        /// <summary>
        /// 可指定返回结果、排序、查询条件的通用查询方法，返回Object对象集合
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">返回结果（必须是模型中存在的字段）</param>
        /// <param name="isAsc">排序方向，true为正序false为倒序</param>
        /// <returns>自定义实体集合</returns>
        List<object> QueryObject<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool isAsc)
            where TEntity : class;

        /// <summary>
        /// 可指定返回结果、排序、查询条件的通用查询方法，返回Object对象集合（异步方式）
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">返回结果（必须是模型中存在的字段）</param>
        /// <param name="isAsc">排序方向，true为正序false为倒序</param>
        /// <returns>自定义实体集合</returns>
        Task<List<object>> QueryObjectAsync<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool isAsc)
            where TEntity : class;

        /// <summary>
        /// 可指定返回结果、排序、查询条件的通用查询方法，返回动态类对象集合
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">返回结果（必须是模型中存在的字段）</param>
        /// <param name="isAsc">排序方向，true为正序false为倒序</param>
        /// <returns>动态类</returns>
        dynamic QueryDynamic<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool isAsc)
            where TEntity : class;

        /// <summary>
        /// 可指定返回结果、排序、查询条件的通用查询方法，返回动态类对象集合（异步方式）
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">返回结果（必须是模型中存在的字段）</param>
        /// <param name="isAsc">排序方向，true为正序false为倒序</param>
        /// <returns>动态类</returns>
        Task<dynamic> QueryDynamicAsync<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool isAsc)
            where TEntity : class;

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <param name="selector"></param>
        /// <param name="total"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        Page<T> PageList(int pageindex, int pagesize, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Expression<Func<T, T>> selector, out int total, Expression<Func<T, bool>> @where = null);

        Page<T> PageList<S>(int pageindex, int pagesize,Expression<Func<T, bool>> predicate, Expression<Func<T, S>> orderPredicate, bool isAsc);

        #endregion

        #region 验证是否存在

        /// <summary>
        /// 验证当前条件是否存在相同项
        /// </summary>
        bool IsExist(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 验证当前条件是否存在相同项（异步方式）
        /// </summary>
        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据SQL验证实体对象是否存在
        /// </summary>
        bool IsExist(string sql, params DbParameter[] para);

        /// <summary>
        /// 根据SQL验证实体对象是否存在（异步方式）
        /// </summary>
        Task<bool> IsExistAsync(string sql, params DbParameter[] para);

        #endregion
    }
}
