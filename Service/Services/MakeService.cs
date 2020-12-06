using Microsoft.EntityFrameworkCore;
using Service.Abstracts;
using Service.Common.Paging;
using Service.Context;
using Service.Interfaces;
using Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MakeService : DataManipulationsBase<VehicleMake>, IMakeService
    {
        public MakeService(VehicleDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<VehicleMake> GetMakeByIdAsync(int Id)
        {
            return await FindByCondition(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<PagedList<VehicleMake>> GetMakesAsync(PagingParameters pagingParams, string SortBy)
        {
            var makes = FindAll().Include(x => x.Models);
            IOrderedQueryable<VehicleMake> orderedMakes = SortBy switch
            {
                "MakeA" => makes.OrderBy(x => x.Name), //redundantno
                "MakeD" => makes.OrderByDescending(x => x.Name),
                _ => makes.OrderBy(x => x.Name),
            };
            return await PagedList<VehicleMake>.ToPagedListAsync(orderedMakes, pagingParams.PageNumber, pagingParams.PageSize);
        }
        public async Task CreateMakeAsync(VehicleMake Make)
        {
            Make.Abrv = GenerateAbrv(Make.Name);
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
        public async Task<IEnumerable<VehicleMake>> GetAllMakesAsync()
        {
            return await FindAll().ToListAsync();
        }
        private string GenerateAbrv(string Name)
        {
            return Name.Replace(" ", "").ToLower();
        }
    }
}
