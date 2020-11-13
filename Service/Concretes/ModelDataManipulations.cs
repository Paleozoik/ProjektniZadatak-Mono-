﻿using Microsoft.EntityFrameworkCore;
using Service.Abstracts;
using Service.Context;
using Service.Interfaces;
using Service.Models;
using Service.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concretes
{
    public class ModelDataManipulations : DataManipulationsBase<VehicleModel>, IModelDataManipulations
    {
        public ModelDataManipulations(VehicleDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<VehicleModel> GetModelByIdAsync(Guid Id)
        {
            return await FindByCondition(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<PagedList<VehicleModel>> GetModelsAsync(ModelPaging pagingParams)
        {
            var models = FindByCondition(x => x.MakeId == pagingParams.MakeFilter || pagingParams.MakeFilter == null).Include(x => x.Make);
            IOrderedQueryable<VehicleModel> orderedModels = pagingParams.SortBy switch
            {
                "MakeA" => models.OrderBy(x => x.Make.Name),
                "MakeD" => models.OrderByDescending(x => x.Make.Name),
                "ModelA" => models.OrderBy(x => x.Name),
                "ModelD" => models.OrderByDescending(x => x.Name),
                _ => models.OrderBy(x => x.Name),
            };
            return await PagedList<VehicleModel>.ToPagedListAsync(orderedModels, pagingParams.PageNumber, pagingParams.PageSize);
        }
        public async Task CreateModelAsync(VehicleModel model)
        {
            await CreateAsync(model);
            await SaveChangesAsync();
        }
        public async Task UpdateModelAsync(VehicleModel model)
        {
            Update(model);
            await SaveChangesAsync();
        }
        public async Task DeleteModelAsync(VehicleModel model)
        {
            Delete(model);
            await SaveChangesAsync();
        }
    }
}
