namespace ShopTest.Interfacies
{
    public interface IRepositoryGeneric<T> where T : class
    {
        Task<T> Create(T objectEntry);
        Task Update(T objectEntry);
        Task Delete(T objectEntry);
        Task<List<T>> List();
        Task<T?> GetById(int id);
    }
}