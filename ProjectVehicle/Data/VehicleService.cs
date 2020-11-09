using Microsoft.EntityFrameworkCore;
using ProjectVehicle.Models;
using System;
using System.Collections.Generic;
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
        public async Task CreateVehicleMakeAsync(VehicleMake make)  //reminder: expecting client-side validation
        {                                                           //design decision: should I be worried about duplicates?
            if (make == null) 
            {
                throw new ArgumentNullException(nameof(make));
            }
            _context.VehicleMake.Add(make);
            await _context.SaveChangesAsync();            
        }
        public async Task CreateVehicleModelAsync(VehicleModel model) //reminder: create for model should have make id constraint
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _context.VehicleModel.Add(model);
            await _context.SaveChangesAsync();
        }


        public async Task<VehicleMake> GetVehicleMakeByIdAsync(int id)
        {
            return await _context.VehicleMake.Include(c => c.VehicleModels).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync()
        {
            return await _context.VehicleMake.ToListAsync();
            //return await _context.VehicleMake.Include(c => c.VehicleModels).ToListAsync(); Naprednija ali ne koristim
        }   

        public async Task<VehicleModel> GetVehicleModelByIdAsync(int id)
        {
            return await _context.VehicleModel.Include(c => c.VehicleMake).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync()
        {
            return await _context.VehicleModel.Include(c => c.VehicleMake).ToListAsync(); 
        }

        public async Task UpdateVehicleMakeAsync(int id, VehicleMake make)
        {
            var vehicleMakeOld = await _context.VehicleMake.FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleMakeOld == null)
            {
                //shouldn't be possible, but...
            }
            vehicleMakeOld.Name = make.Name;
            vehicleMakeOld.Abrv = GenerateAbrv(make.Name);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleModelAsync(int id, VehicleModel model)
        {
            var vehicleModelOld = await _context.VehicleModel.FirstOrDefaultAsync(m => m.Id == id);
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
            await _context.SaveChangesAsync(); //pretty sure I don't need await here
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            var model = await _context.VehicleModel.FindAsync(id);
            _context.VehicleModel.Remove(model);
            await _context.SaveChangesAsync(); //pretty sure I don't need await here
        }


        private string GenerateAbrv(string name)
        {
            return name; //možta tolower i Regex.Replace(name, @"\s+", "")
        }
    }
}
