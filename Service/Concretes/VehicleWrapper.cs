using Service.Context;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concretes
{
    public class VehicleWrapper : IVehicleWrapper
    {
        private readonly VehicleDbContext _dbContext;
        private IMakeDataManipulations _make;
        private IModelDataManipulations _model;
        public IMakeDataManipulations Make { get { if (_make == null) { _make = new MakeDataManipulations(_dbContext); } return _make; } }
        public IModelDataManipulations Model { get { if (_model == null) { _model = new ModelDataManipulations(_dbContext); } return _model; } }
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
