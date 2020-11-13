using Microsoft.EntityFrameworkCore;
using Service.Abstracts;
using Service.Context;
using Service.Interfaces;
using Service.Models;
using Service.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Service.Concretes
{
    public class ModelDataManipulations : DataManipulationsBase<VehicleModel>, IModelDataManipulations 
    {
        public ModelDataManipulations(VehicleDbContext dbContext) : base(dbContext)
        {

        }

        public VehicleModel GetModelById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public PagedList<VehicleModel> GetModels(ModelPaging pagingParams)
        {
            var models = FindByCondition(x => x.MakeId == pagingParams.MakeFilter || pagingParams.MakeFilter == null).Include(x => x.Make);
            IOrderedQueryable<VehicleModel> orderedModels;
            switch (pagingParams.SortBy)
            {
                case "MakeA":
                    orderedModels = models.OrderBy(x => x.Make.Name);
                    break;
                case "MakeD":
                    orderedModels = models.OrderByDescending(x => x.Make.Name);
                    break;
                case "ModelA":
                    orderedModels = models.OrderBy(x => x.Name);
                    break;
                case "ModelD":
                    orderedModels = models.OrderByDescending(x => x.Name);
                    break;
                default:
                    orderedModels = models.OrderBy(x => x.Name);
                    break;
            }
            return PagedList<VehicleModel>.ToPagedList(orderedModels, pagingParams.PageNumber, pagingParams.PageSize);
        }
    }
}
