using Service.Abstracts;
using Service.Context;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concretes
{
    public class ModelDataManipulations : DataManipulationsBase<VehicleModel>, IModelDataManipulations 
    {
        public ModelDataManipulations(VehicleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
