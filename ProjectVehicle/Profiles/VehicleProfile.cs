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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)); //keeping it here for syntax refference
            CreateMap<VehicleModel, ModelGetViewModel>()
                .ForMember(dest => dest.makeName, opt => opt.MapFrom(src => src.VehicleMake.Name));
        }
    }
}
