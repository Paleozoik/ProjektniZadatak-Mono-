using Service.Models;
using Service.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMakeDataManipulations : IDataManipulationsBase<VehicleMake>
    {
        Task<PagedList<VehicleMake>> GetMakesAsync(MakePaging pagingParams);
        Task<VehicleMake> GetMakeByIdAsync(int Id);
        Task CreateMakeAsync(VehicleMake make);
        Task UpdateMakeAsync(VehicleMake make);
        Task DeleteMakeAsync(VehicleMake make);
        Task<IEnumerable<VehicleMake>> GetAllMakesAsync();
    }
}
