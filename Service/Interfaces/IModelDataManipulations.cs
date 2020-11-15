using Service.Abstracts;
using Service.Models;
using Service.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IModelDataManipulations : IDataManipulationsBase<VehicleModel>
    {
        Task<PagedList<VehicleModel>> GetModelsAsync(ModelPaging pagingParams);
        Task<VehicleModel> GetModelByIdAsync(int Id);
        Task CreateModelAsync(VehicleModel model);
        Task UpdateModelAsync(VehicleModel model);
        Task DeleteModelAsync(VehicleModel model);
    }
}
