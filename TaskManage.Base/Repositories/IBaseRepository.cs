using System.Linq.Expressions;

namespace TaskManage.Base.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        #region Get -------------------------------------------------------------------------------
        Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default);
        Task<List<T>> ListAllAsync(bool isTrakingEnable, CancellationToken cancellationToken = default);
        #endregion --------------------------------------------------------------------------------

        #region Add -------------------------------------------------------------------------------
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        void AddWithoutSave(T entity);
        Task AddRangeWithoutSaveAsync(List<T> values, CancellationToken cancellationToken = default);

        #endregion --------------------------------------------------------------------------------

        #region Update ----------------------------------------------------------------------------
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        void UpdateWithoutSave(T entity);
        void UpdateRangeWithoutSave(List<T> values);
        #endregion --------------------------------------------------------------------------------

        #region Delete ----------------------------------------------------------------------------
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        void DeleteWithoutSave(T entity);
        #endregion --------------------------------------------------------------------------------


        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> FindByConditionFirstAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<T> FindByConditionWithTrakingFirstAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> FindByConditionWithTrakingAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<T> GetByIdWithConditionAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<List<T>> ListAllByConditionAsync(bool isTrakingEnable, Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    }
}
