using Service.Common.Paging;
using Service.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMakeService : IDataManipulationsBase<VehicleMake>
    {
        Task<PagedList<VehicleMake>> GetMakesAsync(PagingParameters pagingParams, string SortBy);
        Task<VehicleMake> GetMakeByIdAsync(int Id);
        Task CreateMakeAsync(VehicleMake make);
        Task UpdateMakeAsync(VehicleMake make);
        Task DeleteMakeAsync(VehicleMake make);
        Task<IEnumerable<VehicleMake>> GetAllMakesAsync();
    }
}
