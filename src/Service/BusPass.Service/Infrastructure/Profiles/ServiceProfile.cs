using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusPass.Repository.Models.Api;
using BusPass.Repository.Models.Entities;

namespace BusPass.Service.Infrastructure.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<PtxBusRoute, BusRoute>()
                .ForMember(dest => dest.RouteName, opt => opt.MapFrom(s => s.RouteName.Zh_tw))
                .ForMember(dest => dest.DepartureStop, opt => opt.MapFrom(s => s.DepartureStopNameZh))
                .ForMember(dest => dest.DestinationStop, opt => opt.MapFrom(s => s.DestinationStopNameZh))
                .ForMember(dest => dest.TicketPriceDescription, opt => opt.MapFrom(s => s.TicketPriceDescriptionZh))
                .ForMember(dest => dest.FareBufferZoneDescription, opt => opt.MapFrom(s => s.FareBufferZoneDescriptionZh))
                .ForMember(dest => dest.RouteId, opt => opt.MapFrom(s => long.Parse(s.RouteID)));

            CreateMap<PtxSubRoute, BusSubRoute>()
                .ForMember(dest => dest.SubRouteName, opt => opt.MapFrom(s => s.SubRouteName.Zh_tw))
                .ForMember(dest => dest.SubRouteID, opt => opt.MapFrom(s => long.Parse(s.SubRouteID)))
                .ForMember(dest => dest.OperatorIds, opt => opt.MapFrom(s => s.OperatorIDs.ConvertAll(c => long.Parse(c))));

            CreateMap<PtxOperator, BusOperator>()
                .ForMember(dest => dest.OperatorName, opt => opt.MapFrom(s => s.OperatorName.Zh_tw))
                .ForMember(dest => dest.OperatorID, opt => opt.MapFrom(s => long.Parse(s.OperatorID)));
        }
    }
}