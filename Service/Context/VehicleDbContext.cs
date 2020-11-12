using Microsoft.EntityFrameworkCore;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Context
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions options) : base (options)
        {
        }
        public DbSet<VehicleMake> Makes { get; set; }
        public DbSet<VehicleModel> Models { get; set; }
    }
}
