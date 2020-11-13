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

namespace Service.Concretes
{
    public class MakeDataManipulations : DataManipulationsBase<VehicleMake>, IMakeDataManipulations
    {
        public MakeDataManipulations(VehicleDbContext dbContext) : base (dbContext)
        {
        }

        public VehicleMake GetMakeById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public PagedList<VehicleMake> GetMakes(MakePaging pagingParams)
        {
            var makes = FindAll().Include(x => x.Models);
            IOrderedQueryable<VehicleMake> orderedMakes;
            switch (pagingParams.SortBy)
            {
                case "MakeA":
                    orderedMakes = makes.OrderBy(x => x.Name);
                    break;
                case "MakeD":
                    orderedMakes = makes.OrderByDescending(x => x.Name);
                    break;
                default:
                    orderedMakes = makes.OrderBy(x => x.Name);
                    break;
            }
            return PagedList<VehicleMake>.ToPagedList(orderedMakes, pagingParams.PageNumber, pagingParams.PageSize);
        }
    }
}
