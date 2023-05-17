using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManage.Core.Repositories;

namespace TaskManage.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Properties ------------------------------------------------------------------------
        private readonly DbContext _context;
        #endregion --------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------
        public BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
        }
        #endregion --------------------------------------------------------------------------------

        #region Add -------------------------------------------------------------------------------
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            AddWithoutSave(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public void AddWithoutSave(T entity) => _context.Set<T>().Add(entity);

        public async Task AddRangeWithoutSaveAsync(List<T> values, CancellationToken cancellationToken = default) => await _context.Set<T>().AddRangeAsync(values, cancellationToken);
        #endregion --------------------------------------------------------------------------------

        #region Delete ----------------------------------------------------------------------------
        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {

            DeleteWithoutSave(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void DeleteWithoutSave(T entity) => _context.Set<T>().Remove(entity);
        #endregion --------------------------------------------------------------------------------

        #region Get -------------------------------------------------------------------------------
        public virtual async Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
        {
            var dbset = _context.Set<T>();
            return await dbset.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        public virtual async Task<List<T>> ListAllAsync(bool isTrakingEnable, CancellationToken cancellationToken = default)
        {
            var dbset = _context.Set<T>();
            return isTrakingEnable ? await dbset.ToListAsync(cancellationToken) : await dbset.AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<(int totalRecordCount, List<T> result)> GetPagedListAsync(int skip, int take, Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().AsQueryable();

            query = query.Where(predicate);

            var totalRecords = await query.AsNoTracking().CountAsync();

            var dbResult = await query.Skip(skip).Take(take).AsNoTracking().ToListAsync();
            return (totalRecordCount: totalRecords, result: dbResult);
        }
        #endregion --------------------------------------------------------------------------------

        #region Update ----------------------------------------------------------------------------
        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void UpdateWithoutSave(T entity) => _context.Set<T>().Update(entity);

        public void UpdateRangeWithoutSave(List<T> values) => _context.Set<T>().UpdateRange(values);
        #endregion --------------------------------------------------------------------------------


        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<T> FindByConditionFirstAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().Where(expression).AsNoTracking().FirstAsync(cancellationToken);
        }

        public async Task<T> FindByConditionWithTrakingFirstAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().Where(expression).FirstAsync(cancellationToken);
        }

        //public async Task<T> FindByConditionFirstOrDefaultAsyncAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        //{
        //    return await _context.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        //}

        //public async Task<T> FindByConditionWithTrakingFirstOrDefaultAsyncAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        //{
        //    return await _context.Set<T>().Where(expression).FirstOrDefaultAsync(cancellationToken);
        //}

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> FindByConditionWithTrakingAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().Where(expression).ToListAsync(cancellationToken);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public virtual async Task<T> GetByIdWithConditionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            var dbset = _context.Set<T>();
            return await dbset.Where(expression).FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<List<T>> ListAllByConditionAsync(bool isTrakingEnable, Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            var dbset = _context.Set<T>();
            return isTrakingEnable ? await dbset.Where(expression).ToListAsync(cancellationToken) : await dbset.Where(expression).AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}