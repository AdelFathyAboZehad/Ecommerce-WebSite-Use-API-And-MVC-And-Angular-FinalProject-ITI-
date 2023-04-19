namespace AdminSiteUseMVC.Models.IRepository.IGeneralRepositories
{
    public interface IGereralRepository<TEntity, TId> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TId id);
        Task<TEntity> CreatAsync(TEntity item);
        Task<bool> UpdateAsync(TEntity item);
        Task<bool> DeleteAsync(TId id);

    }
}
