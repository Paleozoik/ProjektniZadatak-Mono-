using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.DTOs;
using Service.Interfaces;
using Service.Models;
using Service.Paging;
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
        public async Task<IActionResult> Index(ModelPaging pagingParams)
        {
            ViewData["sortByModel"] = String.IsNullOrEmpty(pagingParams.SortBy) ? "ModelD" : "";
            ViewData["sortByMake"] = pagingParams.SortBy == "MakeA" ? "MakeD" : "MakeA";

            var PagedModel = await _wrapper.Model.GetModelsAsync(pagingParams);
            var PagedDTO = _mapper.Map<PagedList<ModelDTO>>(PagedModel);

            PagedDTO.CurrentPage = PagedModel.CurrentPage;
            PagedDTO.PageSize = PagedModel.PageSize;
            PagedDTO.TotalCount = PagedModel.TotalCount;
            PagedDTO.TotalPages = PagedModel.TotalPages;

            ViewBag.Data = PagedDTO;
            return View(pagingParams);
        }
        public async Task<IActionResult> Create()
        {
            var makes = await _wrapper.Make.GetAllMakesAsync();

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
                await _wrapper.Model.CreateModelAsync(_mapper.Map<VehicleModel>(model));
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var makes = await _wrapper.Make.GetAllMakesAsync();
            ViewBag.SelectList = makes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var model = await _wrapper.Model.GetModelByIdAsync(id);
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
                await _wrapper.Model.UpdateModelAsync(_mapper.Map<VehicleModel>(model));
                return RedirectToAction("Index");
            }
            return View(model.Id);
        }
        public async Task<IActionResult> Delete(int id)
        {
            VehicleModel model = await _wrapper.Model.GetModelByIdAsync(id);
            if (model == null)
            {
                return BadRequest("Invalid ID");
            }
            await _wrapper.Model.DeleteModelAsync(model);
            return RedirectToAction("Index");
        }
    }
}
