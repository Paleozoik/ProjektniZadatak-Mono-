using Microsoft.AspNetCore.Mvc;
using ProjectVehicle.Data;
using ProjectVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Controllers
{
    // GET api/vehicleController/
    [Route("api/vehicleController")]
    [ApiController]
    public class VehicleDataController : ControllerBase // reminder: base jer nema view
    {
        private readonly IVehicleDataManipulations _dataManipulations;
        public VehicleDataController(IVehicleDataManipulations dataManipulations)
        {
            _dataManipulations = dataManipulations;
        }
        [HttpGet]
        public ActionResult<IEnumerable<VehicleModel>> GetVehicleModels ()
        {
            var vehicleModels = _dataManipulations.GetVehicleModels();
            return Ok(vehicleModels);
        }
        // GET api/vehicleController/{id}
        [HttpGet("{id}")] // reminder: study binding sources
        public ActionResult<VehicleModel> GetVehicleModelById (int id)
        {
            var vehicleModel = _dataManipulations.GetVehicleModelById(id);
            return Ok(vehicleModel);
        }
        /*
        [HttpGet]
        public ActionResult<IEnumerable<VehicleMake>> GetVehicleMakes ()
        {
            var vehicleMakes = _dataManipulations.GetVehicleMakes();
            return Ok(vehicleMakes);
        }
        [HttpGet("{id}")]
        public ActionResult<VehicleMake> GetVehicleMakeById (int id)
        {
            var vehicleMake = _dataManipulations.GetVehicleMakeById(id);
            return Ok(vehicleMake);
        }
        */
    }
}
