using AutoMapper;
using Service.Models;
using Service.DTOs;
using Service.Paging;
using AutoMapper.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ProjectVehicle.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleMake, MakeDTO>()
                .ForMember(dest => dest.ModelNames, opt => opt.MapFrom(src => src.Models.Select(x => x.Name)));
            CreateMap<VehicleModel, ModelDTO>()
                .ForMember(dest => dest.MakeName, opt => opt.MapFrom(src => src.Make.Name));
        }
    }
}
