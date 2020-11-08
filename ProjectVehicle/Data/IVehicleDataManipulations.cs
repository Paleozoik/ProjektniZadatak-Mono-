using ProjectVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Data
{
    public  interface IVehicleDataManipulations
    {
        //Create
        Task CreateVehicleMakeAsync(VehicleMake make);
        Task CreateVehicleModelAsync(VehicleModel model);        
        //Read
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync();
        Task<VehicleModel> GetVehicleModelByIdAsync(int id);
        Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync();
        Task<VehicleMake> GetVehicleMakeByIdAsync(int id);
        //Update
        Task UpdateVehicleMakeAsync(int id, VehicleMake make);
        Task UpdateVehicleModelAsync(int id, VehicleModel model);
        //Delete
        Task DeleteVehicleMakeAsync(int id);
        Task DeleteVehicleModelAsync(int id);

    }
}
