using Microsoft.EntityFrameworkCore.Diagnostics;
using Service.Abstracts;
using Service.Context;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Concretes
{
    public class MakeDataManipulations : DataManipulationsBase<VehicleMake>, IMakeDataManipulations
    {
        public MakeDataManipulations(VehicleDbContext dbContext) : base (dbContext)
        {
        }
    }
}
