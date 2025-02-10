namespace Common.Repositories
{
    public interface IDeleteRepository<TEntity, TId>
    {
        void Delete(TId id);
    }
}