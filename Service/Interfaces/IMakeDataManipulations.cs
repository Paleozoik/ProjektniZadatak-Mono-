using Service.Abstracts;
using Service.Models;
using Service.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IMakeDataManipulations : IDataManipulationsBase<VehicleMake>
    {
        PagedList<VehicleMake> GetMakes(MakePaging pagingParams);
        VehicleMake GetMakeById(Guid Id);
    }
}
