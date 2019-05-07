using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreWebArchitecture.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Core.Models.Order, Data.Order>();
            CreateMap<Data.Order, Core.Models.Order>();
            CreateMap<List<Data.Order>, List<Core.Models.Order>>();

            CreateMap<Data.OrderStatus, Core.Models.OrderStatus>();
            CreateMap<List<Data.OrderStatus>, List<Core.Models.OrderStatus>>();
        }
    }
}