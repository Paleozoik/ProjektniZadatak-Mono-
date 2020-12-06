using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectVehicle.DTOs;
using Service.Interfaces;
using Service.Models;
using Service.Paging;
using System;
using System.Threading.Tasks;

namespace ProjectVehicle.Controllers
{
    public class MakeController : Controller
    {
        private IVehicleWrapper _wrapper;
        private IMapper _mapper;

        public MakeController(IVehicleWrapper wrapper, IMapper mapper)
        {
            _wrapper = wrapper;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(MakePaging pagingParams)
        {
            ViewData["sortBy"] = String.IsNullOrEmpty(pagingParams.SortBy) ? "MakeD" : "";

            var PagedMake = await _wrapper.MakeService.GetMakesAsync(pagingParams);
            var PagedDTO = _mapper.Map<PagedList<MakeDTO>>(PagedMake);

            PagedDTO.CurrentPage = PagedMake.CurrentPage;
            PagedDTO.PageSize = PagedMake.PageSize;
            PagedDTO.TotalCount = PagedMake.TotalCount;
            PagedDTO.TotalPages = PagedMake.TotalPages;

            ViewBag.Data = PagedDTO;
            return View(pagingParams);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMakeDTO make)
        {
            if (ModelState.IsValid)
            {
                await _wrapper.MakeService.CreateMakeAsync(_mapper.Map<VehicleMake>(make));
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> Edit(EditMakeDTO make)
        {
            if (ModelState.IsValid)
            {
                await _wrapper.MakeService.UpdateMakeAsync(_mapper.Map<VehicleMake>(make));
                return RedirectToAction("Index");
            }
            return View(make.Id);
        }

        public async Task<IActionResult> Delete(int id)
        {
            VehicleMake make = await _wrapper.MakeService.GetMakeByIdAsync(id);
            if (make == null)
            {
                return BadRequest("Invalid ID");
            }
            await _wrapper.MakeService.DeleteMakeAsync(make);
            return RedirectToAction("Index");
        }
    }
}
