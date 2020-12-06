using Service.Common.Paging;
using Service.Models;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IModelService : IDataManipulationsBase<VehicleModel>
    {
        Task<PagedList<VehicleModel>> GetModelsAsync(PagingParameters pagingParams, string? SortBy, int? MakeFilter);
        Task<VehicleModel> GetModelByIdAsync(int Id);
        Task CreateModelAsync(VehicleModel model);
        Task UpdateModelAsync(VehicleModel model);
        Task DeleteModelAsync(VehicleModel model);
    }
}
