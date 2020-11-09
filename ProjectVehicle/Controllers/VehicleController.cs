using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectVehicle.Data;
using ProjectVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleDataManipulations _dataManipulations;
        private readonly IMapper _mapper;

        // do we need ILogger?
        public VehicleController(IVehicleDataManipulations dataManipulations, IMapper mapper)
        {
            _dataManipulations = dataManipulations;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Make()
        {
            var readMake = await _dataManipulations.GetVehicleMakesAsync();
            return View(_mapper.Map<IEnumerable<MakeGetViewModel>>(readMake));
        }

        public async Task<IActionResult> Model()
        {
            var readModel = await _dataManipulations.GetVehicleModelsAsync();
            return View(_mapper.Map<IEnumerable<ModelGetViewModel>>(readModel));
        }

    }
}
