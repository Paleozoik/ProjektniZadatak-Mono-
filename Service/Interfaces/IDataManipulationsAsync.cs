using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDataManipulationsAsync<T>
    {
        Task CreateAsync(T entity);
        Task SaveChangesAsync();
    }
}
