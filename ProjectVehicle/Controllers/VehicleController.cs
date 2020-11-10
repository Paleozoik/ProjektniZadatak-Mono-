using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectVehicle.Data;
using ProjectVehicle.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
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

        public async Task<IActionResult> CreateModel()
        {
            var exsistingMakes = await _dataManipulations.GetVehicleMakesAsync();
            return View(new ModelCreateViewModel(exsistingMakes));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateModel(ModelCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _dataManipulations.CreateVehicleModelAsync(_mapper.Map<VehicleModel>(model));
                return RedirectToAction("Model");
            }
            return View(model);
        }

        public IActionResult CreateMake()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMake(MakeCreateViewModel make)
        {
            if (ModelState.IsValid)
            {
                await _dataManipulations.CreateVehicleMakeAsync(_mapper.Map<VehicleMake>(make));
                return RedirectToAction("Make");
            }
            return View();
        }
        public async Task<IActionResult> EditModel(int id)
        {
            VehicleModel model = await _dataManipulations.GetVehicleModelByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            IEnumerable<VehicleMake> exsistingMakes = await _dataManipulations.GetVehicleMakesAsync();
            ModelPutViewModel oldData = new ModelPutViewModel(exsistingMakes);
            oldData.Id = model.Id; // nisam siguran kako bih korsitio AutoMapper u ovom slučaju
            oldData.MakeId = model.MakeId;
            oldData.Name = model.Name;
            return View(oldData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditModel(ModelPutViewModel newData)
        {
            if (ModelState.IsValid) {
            var data = _mapper.Map<VehicleModel>(newData);
            await _dataManipulations.UpdateVehicleModelAsync(data);
            return RedirectToAction("Model");
            }
            return View(newData);
        }
        public async Task<IActionResult> EditMake(int id)
        {
            VehicleMake data = await _dataManipulations.GetVehicleMakeByIdAsync(id);
            if (data == null)
            {
                return BadRequest();
            }
            return View(_mapper.Map<MakePutViewModel>(data));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMake(MakePutViewModel newData)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<VehicleMake>(newData);
                await _dataManipulations.UpdateVehicleMakeAsync(data);
                return RedirectToAction("Make");
            }
            return View(newData);
        }
        public async Task<IActionResult> DeleteModel(int id)
        {
            await _dataManipulations.DeleteVehicleModelAsync(id);
            return RedirectToAction("Model");
        }
        public async Task<IActionResult> DeleteMake(int id)
        {
            await _dataManipulations.DeleteVehicleMakeAsync(id);
            return RedirectToAction("Make");
        }

    }
}
