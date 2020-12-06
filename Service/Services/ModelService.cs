using Microsoft.EntityFrameworkCore;
using Service.Abstracts;
using Service.Common.Paging;
using Service.Context;
using Service.Interfaces;
using Service.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ModelService : DataManipulationsBase<VehicleModel>, IModelService
    {
        public ModelService(VehicleDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<VehicleModel> GetModelByIdAsync(int Id)
        {
            return await FindByCondition(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<PagedList<VehicleModel>> GetModelsAsync(PagingParameters pagingParams, string? SortBy, int? MakeFilter)
        {
            var models = FindByCondition(x => x.MakeId == MakeFilter || MakeFilter == null).Include(x => x.Make);
            IOrderedQueryable<VehicleModel> orderedModels = SortBy switch
            {
                "MakeA" => models.OrderBy(x => x.Make.Name), //redundantno
                "MakeD" => models.OrderByDescending(x => x.Make.Name),
                "ModelA" => models.OrderBy(x => x.Name),
                "ModelD" => models.OrderByDescending(x => x.Name),
                _ => models.OrderBy(x => x.Name),
            };
            return await PagedList<VehicleModel>.ToPagedListAsync(orderedModels, pagingParams.PageNumber, pagingParams.PageSize);
        }
        public async Task CreateModelAsync(VehicleModel model)
        {
            model.Abrv = GenerateAbrv(model.Name);
            await CreateAsync(model);
            await SaveChangesAsync();
        }
        public async Task UpdateModelAsync(VehicleModel model)
        {
            model.Abrv = GenerateAbrv(model.Name);
            Update(model);
            await SaveChangesAsync();
        }
        public async Task DeleteModelAsync(VehicleModel model)
        {
            Delete(model);
            await SaveChangesAsync();
        }
        private string GenerateAbrv(string Name)
        {
            return Name.Replace(" ", "").ToLower();
        }
    }
}
