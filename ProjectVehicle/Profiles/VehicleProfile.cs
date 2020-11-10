using AutoMapper;
using ProjectVehicle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleMake, MakeGetViewModel>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.VehicleModels.Select(c => c.Name)));
            CreateMap<VehicleModel, ModelGetViewModel>()
                .ForMember(dest => dest.MakeName, opt => opt.MapFrom(src => src.VehicleMake.Name));
            CreateMap<ModelCreateViewModel, VehicleModel>();
            CreateMap<MakeCreateViewModel, VehicleMake>();
            CreateMap<ModelPutViewModel, VehicleModel>();
            CreateMap<MakePutViewModel, VehicleMake>();
            CreateMap<VehicleMake, MakePutViewModel>();
        }
    }
}
