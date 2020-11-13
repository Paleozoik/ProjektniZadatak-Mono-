using Service.Abstracts;
using Service.Models;
using Service.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IModelDataManipulations : IDataManipulationsBase<VehicleModel>
    {
        PagedList<VehicleModel> GetModels(ModelPaging pagingParams);
        VehicleModel GetModelById(Guid Id);
    }
}
