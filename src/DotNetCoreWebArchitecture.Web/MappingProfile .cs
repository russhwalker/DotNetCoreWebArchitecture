using AutoMapper;
using System.Collections.Generic;

namespace DotNetCoreWebArchitecture.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Core.Models.Order, Data.Order>();
            CreateMap<Data.Order, Core.Models.Order>();

            CreateMap<Core.Models.ErrorLog, Data.ErrorLog>();
            CreateMap<Data.ErrorLog, Core.Models.ErrorLog>();

            CreateMap<Data.OrderStatus, Core.Models.OrderStatus>();
            CreateMap<List<Data.OrderStatus>, List<Core.Models.OrderStatus>>();
        }
    }
}