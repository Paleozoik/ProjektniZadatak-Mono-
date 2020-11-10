using Microsoft.EntityFrameworkCore;
using ProjectVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Data
{
    public class VehicleService : IVehicleDataManipulations
    {
        private readonly VehicleDbContext _context;

        public VehicleService(VehicleDbContext context)
        {
            _context = context;
        }
        public async Task CreateVehicleMakeAsync(VehicleMake make)
        {                                                           //design decision: should I be worried about duplicates?
            if (make == null) 
            {
                throw new ArgumentNullException(nameof(make));
            }
            make.Abrv = GenerateAbrv(make.Name);
            _context.VehicleMake.Add(make);
            await _context.SaveChangesAsync();            
        }
        public async Task CreateVehicleModelAsync(VehicleModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            model.Abrv = GenerateAbrv(model.Name);
            _context.VehicleModel.Add(model);
            await _context.SaveChangesAsync();
        }


        public async Task<VehicleMake> GetVehicleMakeByIdAsync(int id)
        {
            return await _context.VehicleMake.Include(c => c.VehicleModels).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync()
        {
            return await _context.VehicleMake.Include(c => c.VehicleModels).ToListAsync();
        }   


        public async Task<VehicleModel> GetVehicleModelByIdAsync(int id)
        {
            return await _context.VehicleModel.Include(c => c.VehicleMake).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync()
        {
            return await _context.VehicleModel.Include(c => c.VehicleMake).ToListAsync(); 
        }

        public async Task UpdateVehicleMakeAsync(VehicleMake make)
        {
            var vehicleMakeOld = await _context.VehicleMake.FirstOrDefaultAsync(m => m.Id == make.Id);
            if (vehicleMakeOld == null)
            {
                //shouldn't be possible, but...
            }
            vehicleMakeOld.Name = make.Name;
            vehicleMakeOld.Abrv = GenerateAbrv(make.Name);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleModelAsync(VehicleModel model)
        {
            var vehicleModelOld = await _context.VehicleModel.FirstOrDefaultAsync(m => m.Id == model.Id);
            if (vehicleModelOld == null)
            {
                //shouldn't be possible, but...
            }
            vehicleModelOld.Name = model.Name;
            vehicleModelOld.Abrv = GenerateAbrv(model.Name);
            vehicleModelOld.MakeId = model.MakeId;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteVehicleMakeAsync(int id)
        {
            var make = await _context.VehicleMake.FindAsync(id);
            _context.VehicleMake.Remove(make);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            var model = await _context.VehicleModel.FindAsync(id);
            _context.VehicleModel.Remove(model);
            await _context.SaveChangesAsync();
        }


        private string GenerateAbrv(string name)
        {
            return name; //možta tolower i Regex.Replace(name, @"\s+", "")
        }
    }
}
