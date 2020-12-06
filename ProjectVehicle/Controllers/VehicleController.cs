using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectVehicle.DTOs;
using Service.Interfaces;
using Service.Models;
using Service.Paging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleWrapper _wrapper;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleWrapper wrapper, IMapper mapper)
        {
            _wrapper = wrapper;
            _mapper = mapper;
        }
        public async Task<IActionResult> Make(MakePaging pagingParams)
        {
            ViewData["sortBy"] = String.IsNullOrEmpty(pagingParams.SortBy) ? "MakeD" : "";

            var PagedMake = await _wrapper.MakeService.GetMakesAsync(pagingParams);
            var PagedDTO = _mapper.Map<PagedList<MakeDTO>>(PagedMake);

            PagedDTO.CurrentPage = PagedMake.CurrentPage; //Nisam siguran kako bih to napravio sa AutoMapper-om
            PagedDTO.PageSize = PagedMake.PageSize;
            PagedDTO.TotalCount = PagedMake.TotalCount;
            PagedDTO.TotalPages = PagedMake.TotalPages;

            ViewBag.Data = PagedDTO;
            return View(pagingParams);
        }

        public async Task<IActionResult> Model(ModelPaging pagingParams)
        {
            ViewData["sortByModel"] = String.IsNullOrEmpty(pagingParams.SortBy) ? "ModelD" : "";
            ViewData["sortByMake"] = pagingParams.SortBy == "MakeA" ? "MakeD" : "MakeA";

            var PagedModel = await _wrapper.ModelService.GetModelsAsync(pagingParams);
            var PagedDTO = _mapper.Map<PagedList<ModelDTO>>(PagedModel);

            PagedDTO.CurrentPage = PagedModel.CurrentPage; //Nisam siguran kako bih to napravio sa AutoMapper-om
            PagedDTO.PageSize = PagedModel.PageSize;
            PagedDTO.TotalCount = PagedModel.TotalCount;
            PagedDTO.TotalPages = PagedModel.TotalPages;

            ViewBag.Data = PagedDTO;
            return View(pagingParams);
        }
        public async Task<IActionResult> CreateModel()
        {
            var makes = await _wrapper.MakeService.GetAllMakesAsync();

            ViewBag.SelectList = makes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateModel(CreateModelDTO model)
        {
            if (ModelState.IsValid)
            {
                await _wrapper.ModelService.CreateModelAsync(_mapper.Map<VehicleModel>(model));
                return RedirectToAction("Model");
            }
            return View();
        }
        public IActionResult CreateMake()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMake(CreateMakeDTO make)
        {
            if (ModelState.IsValid)
            {
                await _wrapper.MakeService.CreateMakeAsync(_mapper.Map<VehicleMake>(make));
                return RedirectToAction("Make");
            }
            return View();
        }
        public async Task<IActionResult> EditModel(int id)
        {
            var makes = await _wrapper.MakeService.GetAllMakesAsync();
            ViewBag.SelectList = makes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var model = await _wrapper.ModelService.GetModelByIdAsync(id);
            if (model == null)
            {
                return BadRequest("Invalid ID");
            }
            return View(_mapper.Map<EditModelDTO>(model));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditModel(EditModelDTO model)
        {
            if (ModelState.IsValid)
            {
                await _wrapper.ModelService.UpdateModelAsync(_mapper.Map<VehicleModel>(model));
                return RedirectToAction("Model");
            }
            return View(model.Id);
        }
        public async Task<IActionResult> EditMake(int id)
        {
            var make = await _wrapper.MakeService.GetMakeByIdAsync(id);
            if (make == null)
            {
                return BadRequest("Invalid ID");
            }
            return View(_mapper.Map<EditMakeDTO>(make));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMake(EditMakeDTO make)
        {
            if (ModelState.IsValid)
            {
                await _wrapper.MakeService.UpdateMakeAsync(_mapper.Map<VehicleMake>(make));
                return RedirectToAction("Make");
            }
            return View(make.Id);
        }
        public async Task<IActionResult> DeleteModel(int id)
        {
            VehicleModel model = await _wrapper.ModelService.GetModelByIdAsync(id);
            if (model == null)
            {
                return BadRequest("Invalid ID");
            }
            await _wrapper.ModelService.DeleteModelAsync(model);
            return RedirectToAction("Model");
        }
        public async Task<IActionResult> DeleteMake(int id)
        {
            VehicleMake make = await _wrapper.MakeService.GetMakeByIdAsync(id);
            if (make == null)
            {
                return BadRequest("Invalid ID");
            }
            await _wrapper.MakeService.DeleteMakeAsync(make);
            return RedirectToAction("Make");
        }
    }
}
