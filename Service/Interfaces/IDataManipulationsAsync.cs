using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDataManipulationsAsync<T>
    {
        Task CreateAsync(T entity);
        Task SaveChangesAsync();
    }
}
