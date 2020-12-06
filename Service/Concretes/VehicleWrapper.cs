using Service.Context;
using Service.Interfaces;
using Service.Services;

namespace Service.Concretes
{
    public class VehicleWrapper : IVehicleWrapper
    {
        private readonly VehicleDbContext _dbContext;
        private IMakeService _make;
        private IModelService _model;
        public IMakeService MakeService { get { if (_make == null) { _make = new MakeService(_dbContext); } return _make; } }
        public IModelService ModelService { get { if (_model == null) { _model = new ModelService(_dbContext); } return _model; } }
        public VehicleWrapper(VehicleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
