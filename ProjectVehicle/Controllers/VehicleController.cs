using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectVehicle.Models;
using Service.DTOs;
using Service.Interfaces;
using Service.Models;
using Service.Paging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ProjectVehicle.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleWrapper _wrapper;
        private readonly IMapper _mapper;

        // do we need ILogger?
        public VehicleController(IVehicleWrapper wrapper, IMapper mapper)
        {
            _wrapper = wrapper;
            _mapper = mapper;
        }
        public async Task<IActionResult> Make(MakePaging pagingParams)
        {
            ViewData["sortBy"] = String.IsNullOrEmpty(pagingParams.SortBy) ? "MakeD" : "";
            var PagedMake = await _wrapper.Make.GetMakesAsync(pagingParams);
            var PagedDTO = _mapper.Map<PagedList<MakeDTO>>(PagedMake);

            PagedDTO.CurrentPage = PagedMake.CurrentPage; //Nisam siguran kako bih to napravio sa AutoMapper-om
            PagedDTO.PageSize = PagedMake.PageSize;
            PagedDTO.TotalCount = PagedMake.TotalCount;
            PagedDTO.TotalPages = PagedMake.TotalPages;

            ViewBag.Data = PagedDTO;
            return View();
        }

        public async Task<IActionResult> Model(ModelPaging pagingParams)
        {
            ViewData["sortByModel"] = String.IsNullOrEmpty(pagingParams.SortBy) ? "ModelD" : "";
            ViewData["sortByMake"] = pagingParams.SortBy == "MakeA" ? "MakeD" : "MakeA";
            
            var PagedModel = await _wrapper.Model.GetModelsAsync(pagingParams);
            var PagedDTO = _mapper.Map<PagedList<ModelDTO>>(PagedModel);
            
            PagedDTO.PageSize = PagedModel.PageSize;
            PagedDTO.TotalCount = PagedModel.TotalCount;
            PagedDTO.TotalPages = PagedModel.TotalPages;

            ViewBag.Data = PagedDTO;
            return View();
        }
        /*
public async Task<IActionResult> CreateModel()
{

    return View();
}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> CreateModel(VehicleModel model)
{
    if (ModelState.IsValid)
    {

        return RedirectToAction();
    }
    return View();
}

public IActionResult CreateMake()
{
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> CreateMake(VehicleMake make)
{
    if (ModelState.IsValid)
    {
        return RedirectToAction("Make");
    }
    return View();
}
public async Task<IActionResult> EditModel(int id)
{

    return View();
}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> EditModel()
{

    return View();
}
public async Task<IActionResult> EditMake(int id)
{

    return View();
}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> EditMake()
{

    return View();
}
public async Task<IActionResult> DeleteModel()
{
    return RedirectToAction("Model");
}
public async Task<IActionResult> DeleteMake()
{
    return RedirectToAction("Make");
}
*/
    }
}
