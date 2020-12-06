using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectVehicle.DTOs;
using Service.Common.Paging;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Controllers
{
    public class ModelController : Controller
    {
        private IVehicleWrapper _wrapper;
        private IMapper _mapper;

        public ModelController(IVehicleWrapper wrapper, IMapper mapper)
        {
            _wrapper = wrapper;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(PagingParameters pagingParams, string? SortBy, int? MakeFilter)
        {
            ViewData["sortByModel"] = String.IsNullOrEmpty(SortBy) ? "ModelD" : "";
            ViewData["sortByMake"] = SortBy == "MakeA" ? "MakeD" : "MakeA";

            ViewData["makeFilter"] = MakeFilter;
            ViewData["sortBy"] = SortBy;

            var PagedModel = await _wrapper.ModelService.GetModelsAsync(pagingParams, SortBy, MakeFilter);
            PagedList<ModelDTO> PagedDTO = new PagedList<ModelDTO>(_mapper.Map<List<ModelDTO>>(PagedModel), PagedModel.TotalCount, PagedModel.CurrentPage, PagedModel.PageSize);


            ViewBag.Data = PagedDTO;
            return View(pagingParams);
        }
        public async Task<IActionResult> Create()
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
        public async Task<IActionResult> Create(CreateModelDTO model)
        {
            if (ModelState.IsValid)
            {
                await _wrapper.ModelService.CreateModelAsync(_mapper.Map<VehicleModel>(model));
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> Edit(EditModelDTO model)
        {
            if (ModelState.IsValid)
            {
                await _wrapper.ModelService.UpdateModelAsync(_mapper.Map<VehicleModel>(model));
                return RedirectToAction("Index");
            }
            return View(model.Id);
        }
        public async Task<IActionResult> Delete(int id)
        {
            VehicleModel model = await _wrapper.ModelService.GetModelByIdAsync(id);
            if (model == null)
            {
                return BadRequest("Invalid ID");
            }
            await _wrapper.ModelService.DeleteModelAsync(model);
            return RedirectToAction("Index");
        }
    }
}
