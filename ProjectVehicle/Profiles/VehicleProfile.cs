using AutoMapper;
using Service.Models;
using Service.DTOs;
using AutoMapper.Internal;
using System.Collections.Generic;
using System.Linq;

namespace ProjectVehicle.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleMake, MakeDTO>()
                .ForMember(dest => dest.ModelNames, opt => opt.MapFrom(src => src.Models.Select(x => x.Name)));
            CreateMap<VehicleModel, ModelDTO>()
                .ForMember(dest => dest.MakeName, opt => opt.MapFrom(src => src.Make.Name))
                .ForMember(dest => dest.MakeId, opt => opt.MapFrom(src => src.MakeId));
            CreateMap<CreateMakeDTO, VehicleMake>();
            CreateMap<CreateModelDTO, VehicleModel>();
            CreateMap<EditMakeDTO, VehicleMake>();
            CreateMap<VehicleMake, EditMakeDTO>();
            CreateMap<EditModelDTO, VehicleModel>();
            CreateMap<VehicleModel, EditModelDTO>();
        }
    }
}
