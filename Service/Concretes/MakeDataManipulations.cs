using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public class MakeDataManipulations : DataManipulationsBase<VehicleMake>, IMakeDataManipulations
    {
        public MakeDataManipulations(VehicleDbContext dbContext) : base (dbContext)
        {
        }

        public async Task<VehicleMake> GetMakeByIdAsync(int Id)
        {
            return await FindByCondition(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<PagedList<VehicleMake>> GetMakesAsync(MakePaging pagingParams)
        {
            var makes = FindAll().Include(x => x.Models);
            IOrderedQueryable<VehicleMake> orderedMakes = pagingParams.SortBy switch
            {
                "MakeD" => makes.OrderByDescending(x => x.Name),
                _ => makes.OrderBy(x => x.Name),
            };
            return await PagedList<VehicleMake>.ToPagedListAsync(orderedMakes, pagingParams.PageNumber, pagingParams.PageSize);
        }
        public async Task CreateMakeAsync(VehicleMake Make)
        {
            await CreateAsync(Make);
            await SaveChangesAsync();
        }
        public async Task UpdateMakeAsync(VehicleMake Make)
        {
            Update(Make);
            await SaveChangesAsync();
        }
        public async Task DeleteMakeAsync(VehicleMake Make)
        {
            Delete(Make);
            await SaveChangesAsync();
        }
    }
}
