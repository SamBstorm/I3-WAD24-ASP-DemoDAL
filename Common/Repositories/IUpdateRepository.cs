namespace Common.Repositories
{
    public interface IUpdateRepository<TEntity, TId>
    {
        void Update(TId id, TEntity entity);
    }
}