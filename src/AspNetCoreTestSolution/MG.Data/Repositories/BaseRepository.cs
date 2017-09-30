using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MG.Entity.DbContext;
using MG.Infrastructure.Core;
using MG.Infrastructure.Repositories;
using MG.Infrastructure.WebControls;
using MG.Infrastructure.WebControls;
using MG.Entity.DbContext;

namespace MG.Data.Repositories
{
    /// <summary>
    /// 仓储数据访问基接口实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        #region 数据上下文

        /// <summary>
        /// 数据上下文
        /// </summary>
        private readonly ProjectContext _context;

        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        public IQueryable<T> Entities => _context.Set<T>();

        public BaseRepository(ProjectContext context, IUnitOfWork unitOfWork)
        {
            this._context = context;
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region 单模型 CRUD 操作

        public virtual bool Save(T entity, bool isCommit = true)
        {
            _context.Add(entity);
            if (isCommit)
            {
                return _unitOfWork.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<bool> SaveAsync(T entity, bool isCommit = true)
        {
            _context.Set<T>().Add(entity);
            if (isCommit)
            {
                return await Task.Run(() => _unitOfWork.SaveChanges() > 0);
            }
            else
            {
                return await Task.Run(() => false);
            }
        }

        public virtual bool Update(T entity, bool isCommit = true)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }

            if (isCommit)
            {

                return _unitOfWork.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<bool> UpdateAsync(T entity, bool isCommit = true)
        {
            //_context.Set<T>().Attach(entity);
            //_context.Entry<T>(entity).State = EntityState.Modified;
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            if (isCommit)
            {
                return await Task.Run(() => _unitOfWork.SaveChanges() > 0);
            }
            else
            {
                return await Task.Run(() => false);
            }
        }

        public virtual bool SaveOrUpdate(T entity, bool isSave, bool isCommit = true)
        {
            return isSave ? Save(entity, isCommit) : Update(entity, isCommit);
        }

        public virtual async Task<bool> SaveOrUpdateAsync(T entity, bool isSave, bool isCommit = true)
        {
            return isSave ? await SaveAsync(entity, isCommit) : await UpdateAsync(entity, isCommit);
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            //return _context.Set<T>().AsNoTracking().SingleOrDefault(predicate);
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public virtual T Get(object key)
        {
            return _context.Set<T>().Find(key);
        }

        public virtual async Task<T> GetAsync(object key)
        {
            return await Task.Run(() => _context.Set<T>().Find(key));
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => _context.Set<T>().SingleOrDefault(predicate));
        }

        public virtual bool Delete(T entity, bool isCommit = true)
        {
            if (entity == null)
            {
                return false;
            }
            _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
            if (isCommit)
            {
                return _unitOfWork.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<bool> DeleteAsync(T entity, bool isCommit = true)
        {
            if (entity == null)
            {
                return await Task.Run(() => false);
            }
            _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
            if (isCommit)
            {
                return await Task.Run(() => _unitOfWork.SaveChanges() > 0);
            }
            else
            {
                return await Task.Run(() => false);
            }
        }

        #endregion

        #region 多模型 操作

        public virtual bool SaveList(List<T> entities, bool isCommit = true)
        {
            if (entities == null || !entities.Any())
            {
                return false;
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<T>().Add(item);
            });
            if (isCommit)
            {
                return _unitOfWork.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<bool> SaveListAsync(List<T> entities, bool isCommit = true)
        {
            if (entities == null || !entities.Any())
            {
                return await Task.Run(() => false);
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<T>().Add(item);
            });
            if (isCommit)
            {
                return await Task.Run(() => _unitOfWork.SaveChanges() > 0);
            }
            else
            {
                return await Task.Run(() => false);
            }
        }

        public virtual bool SaveList<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class
        {
            if (entities == null || !entities.Any())
            {
                return false;
            }
            var tmp = _context.ChangeTracker.Entries<T>().ToList();
            foreach (var x in tmp)
            {
                var properties = typeof(T).GetTypeInfo().GetProperties();
                foreach (var y in properties)
                {
                    var entry = x.Property(y.Name);
                    entry.CurrentValue = entry.OriginalValue;
                    entry.IsModified = false;
                    y.SetValue(x.Entity, entry.OriginalValue);
                }
                x.State = EntityState.Unchanged;
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<TEntity>().Add(item);
            });
            if (isCommit)
            {
                return _unitOfWork.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<bool> SaveListAsync<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class
        {
            if (entities == null || !entities.Any())
            {
                return await Task.Run(() => false);
            }
            var tmp = _context.ChangeTracker.Entries<T>().ToList();
            foreach (var x in tmp)
            {
                var properties = typeof(T).GetTypeInfo().GetProperties();
                foreach (var y in properties)
                {
                    var entry = x.Property(y.Name);
                    entry.CurrentValue = entry.OriginalValue;
                    entry.IsModified = false;
                    y.SetValue(x.Entity, entry.OriginalValue);
                }
                x.State = EntityState.Unchanged;
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<TEntity>().Add(item);
            });
            if (isCommit)
            {
                return await Task.Run(() => _unitOfWork.SaveChanges() > 0);
            }
            else
            {
                return await Task.Run(() => false);
            }
        }

        public virtual bool UpdateList(List<T> entities, bool isCommit = true)
        {
            if (entities == null || !entities.Any())
            {
                return false;
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<T>().Attach(item);
                _context.Entry<T>(item).State = EntityState.Modified;
            });
            if (isCommit)
            {
                return _unitOfWork.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<bool> UpdateListAsync(List<T> entities, bool isCommit = true)
        {
            if (entities == null || !entities.Any())
            {
                return await Task.Run(() => false);
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<T>().Attach(item);
                _context.Entry<T>(item).State = EntityState.Modified;
            });
            if (isCommit)
            {
                return await Task.Run(() => _unitOfWork.SaveChanges() > 0);
            }
            else
            {
                return await Task.Run(() => false);
            }
        }

        public virtual bool UpdateList<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class
        {
            if (entities == null || !entities.Any())
            {
                return false;
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<TEntity>().Attach(item);
                _context.Entry<TEntity>(item).State = EntityState.Modified;
            });
            if (isCommit)
            {
                return _unitOfWork.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<bool> UpdateListAsync<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class
        {
            if (entities == null || !entities.Any())
            {
                return await Task.Run(() => false);
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<TEntity>().Attach(item);
                _context.Entry<TEntity>(item).State = EntityState.Modified;
            });
            if (isCommit)
            {
                return await Task.Run(() => _unitOfWork.SaveChanges() > 0);
            }
            else
            {
                return await Task.Run(() => false);
            }
        }

        public virtual bool Delete(Expression<Func<T, bool>> predicate, bool isCommit = true)
        {
            IQueryable<T> entry = (predicate == null) ? _context.Set<T>().AsQueryable() : _context.Set<T>().Where(predicate);
            List<T> list = entry.ToList();
            if (list != null && list.Count == 0)
            {
                return false;
            }
            list.ForEach(item =>
            {
                _context.Set<T>().Attach(item);
                _context.Set<T>().Remove(item);
            });
            if (isCommit)
            {
                return _unitOfWork.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, bool isCommit = true)
        {
            IQueryable<T> entry = (predicate == null) ? _context.Set<T>().AsQueryable() : _context.Set<T>().Where(predicate);
            List<T> list = entry.ToList();
            if (list != null && list.Count == 0)
            {
                return await Task.Run(() => false);
            }
            list.ForEach(item =>
            {
                _context.Set<T>().Attach(item);
                _context.Set<T>().Remove(item);
            });
            if (isCommit)
            {
                return await Task.Run(() => _unitOfWork.SaveChanges() > 0);
            }
            else
            {
                return await Task.Run(() => false);
            }
        }

        public virtual bool DeleteList(List<T> entities, bool isCommit = true)
        {
            if (entities == null || !entities.Any())
            {
                return false;
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<T>().Attach(item);
                _context.Set<T>().Remove(item);
            });
            if (isCommit)
            {
                return _unitOfWork.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<bool> DeleteListAsync(List<T> entities, bool isCommit = true)
        {
            if (entities == null || !entities.Any())
            {
                return await Task.Run(() => false);
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<T>().Attach(item);
                _context.Set<T>().Remove(item);
            });
            if (isCommit)
            {
                return await Task.Run(() => _unitOfWork.SaveChanges() > 0);
            }
            else
            {
                return await Task.Run(() => false);
            }
        }

        public virtual bool DeleteList<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class
        {
            if (entities == null || !entities.Any())
            {
                return false;
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<TEntity>().Attach(item);
                _context.Set<TEntity>().Remove(item);
            });
            if (isCommit)
            {
                return _unitOfWork.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<bool> DeleteListAsync<TEntity>(List<TEntity> entities, bool isCommit = true) where TEntity : class
        {
            if (entities == null || !entities.Any())
            {
                return await Task.Run(() => false);
            }
            entities.ToList().ForEach(item =>
            {
                _context.Set<TEntity>().Attach(item);
                _context.Set<TEntity>().Remove(item);
            });
            if (isCommit)
            {
                return await Task.Run(() => _unitOfWork.SaveChanges() > 0);
            }
            else
            {
                return await Task.Run(() => false);
            }
        }

        #endregion

        #region 获取多条数据操作

        public virtual IQueryable<T> LoadAll(Expression<Func<T, bool>> predicate)
        {
            return predicate != null ? _context.Set<T>().Where(predicate) : _context.Set<T>().AsQueryable<T>();
        }

        public virtual async Task<IQueryable<T>> LoadAllAsync(Expression<Func<T, bool>> predicate)
        {
            return predicate != null ? await Task.Run(() => _context.Set<T>().Where(predicate)) : await Task.Run(() => _context.Set<T>().AsQueryable<T>());
        }

        public virtual List<T> LoadListAll(Expression<Func<T, bool>> predicate)
        {
            return predicate != null ? _context.Set<T>().Where(predicate).ToList() : _context.Set<T>().AsQueryable<T>().ToList();
        }

        public virtual async Task<List<T>> LoadListAllAsync(Expression<Func<T, bool>> predicate)
        {
            return predicate != null ? await Task.Run(() => _context.Set<T>().Where(predicate).ToList()) : await Task.Run(() => _context.Set<T>().AsQueryable<T>().ToList());
        }

        public virtual IQueryable<T> LoadAllBySql(string sql, params DbParameter[] para)
        {
            return _context.Set<T>().FromSql(sql, para);
        }

        public virtual async Task<IQueryable<T>> LoadAllBySqlAsync(string sql, params DbParameter[] para)
        {
            return await Task.Run(() => _context.Set<T>().FromSql(sql, para));
        }

        public virtual List<T> LoadListAllBySql(string sql, params DbParameter[] para)
        {
            return _context.Set<T>().FromSql(sql, para).Cast<T>().ToList();
        }

        public virtual async Task<List<T>> LoadListAllBySqlAsync(string sql, params DbParameter[] para)
        {
            return await Task.Run(() => _context.Set<T>().FromSql(sql, para).Cast<T>().ToList());
        }

        public virtual List<TResult> QueryEntity<TEntity, TOrderBy, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool isAsc)
    where TEntity : class
    where TResult : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (where != null)
            {
                query = query.Where(where);
            }
            if (orderby != null)
            {
                query = isAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }
            if (selector == null)
            {
                return query.Cast<TResult>().ToList();
            }
            return query.Select(selector).ToList();
        }

        public virtual async Task<List<TResult>> QueryEntityAsync<TEntity, TOrderBy, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool isAsc)
            where TEntity : class
            where TResult : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (where != null)
            {
                query = query.Where(where);
            }
            if (orderby != null)
            {
                query = isAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }
            if (selector == null)
            {
                return await Task.Run(() => query.Cast<TResult>().ToList());
            }
            return await Task.Run(() => query.Select(selector).ToList());
        }

        public virtual List<object> QueryObject<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool isAsc) where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (where != null)
            {
                query = query.Where(where);
            }
            if (orderby != null)
            {
                query = isAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }
            if (selector == null)
            {
                return query.ToList<object>();
            }
            return selector(query);
        }

        public virtual async Task<List<object>> QueryObjectAsync<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool isAsc) where TEntity : class
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderby != null)
            {
                query = isAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }
            if (selector == null)
            {
                return await Task.Run(() => query.ToList<object>());
            }
            return await Task.Run(() => selector(query));
        }

        public virtual dynamic QueryDynamic<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool isAsc) where TEntity : class
        {
            //List<object> list = QueryObject<TEntity, TOrderBy>
            //     (where, orderby, selector, isAsc);
            //return Common.JsonHelper.JsonConvert.JsonClass(list);
            throw new NotImplementedException();
        }

        public virtual async Task<dynamic> QueryDynamicAsync<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool isAsc) where TEntity : class
        {
            //       List<object> list = QueryObject<TEntity, TOrderBy>
            //(where, orderby, selector, isAsc);
            //       return await Task.Run(() => Common.JsonHelper.JsonConvert.JsonClass(list));
            throw new NotImplementedException();
        }

        #endregion

        #region 验证是否存在

        public virtual bool IsExist(Expression<Func<T, bool>> predicate)
        {
            var entry = _context.Set<T>().Where(predicate);
            return (entry.Any());
        }

        public virtual async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate)
        {
            var entry = _context.Set<T>().Where(predicate);
            return await Task.Run(() => entry.Any());
        }

        public virtual bool IsExist(string sql, params DbParameter[] para)
        {
            return _context.Database.ExecuteSqlCommand(sql, para) > 0;
        }

        public virtual async Task<bool> IsExistAsync(string sql, params DbParameter[] para)
        {
            return await Task.Run(() => _context.Database.ExecuteSqlCommand(sql, para) > 0);
        }

        #endregion

        public virtual Page<T> PageList(int pageindex, int pagesize, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Expression<Func<T, T>> selector, out int total, Expression<Func<T, bool>> where = null)
        {
            int row = (--pageindex) * pagesize;

            if (where != null)
            {
                total = _context.Set<T>().Where(where).Count();

                var data = orderBy(_context.Set<T>().Where(where))
                    .Skip(row)
                    .Take(pagesize)
                    .Select(selector).ToList();

                var res = new Page<T>(data, pagesize, total);
                return res;
            }
            else
            {
                total = _context.Set<T>().Count();
                var data = orderBy(_context.Set<T>()).Skip(row)
                    .Take(pagesize)
                    .Select(selector).ToList();

                var res = new Page<T>(data, pagesize, total);
                return res;
            }
        }

        public virtual Page<T> PageList<S>(int pageindex, int pagesize, Expression<Func<T, bool>> predicate, Expression<Func<T, S>> orderPredicate, bool isAsc)
        {
            var data = _context.Set<T>().AsQueryable();
            if (predicate != null)
            {
                data = data.Where(predicate);
            }
            var count = data.Count();
            if (isAsc)
            {
                data = data.OrderBy(orderPredicate).Skip((pageindex - 1) * pagesize).Take(pagesize);
                return new Page<T>(data.ToList(), pagesize, count);
            }
            else
            {
                data = data.OrderByDescending(orderPredicate).Skip((pageindex - 1) * pagesize).Take(pagesize);
                return new Page<T>(data.ToList(), pagesize, count);
            }
        }
    }
}
