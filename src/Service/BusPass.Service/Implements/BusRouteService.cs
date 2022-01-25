using AutoMapper;
using BusPass.Repository.Interfaces;
using BusPass.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusPass.Repository.Models.Entities;

namespace BusPass.Service.Implements
{
    public class BusRouteService : IBusRouteService
    {
        private readonly IBusOperatorRepository _busOperatorRepository;
        private readonly IBusRouteRepository _busRouteRepository;
        private readonly IBusSubRouteRepositoey _busSubRouteRepositoey;
        private readonly IBusRouteRelationRepository _busRouteRelationRepository;
        private readonly ICityBusProxy _cityBusProxy;
        private readonly IMapper _mapper;

        public BusRouteService(IBusOperatorRepository busOperatorRepository,
            IBusRouteRepository busRouteRepository,
            IBusSubRouteRepositoey busSubRouteRepositoey,
            IBusRouteRelationRepository busRouteRelationRepository,
            ICityBusProxy cityBusProxy,
            IMapper mapper)
        {
            _busOperatorRepository = busOperatorRepository;
            _busRouteRepository = busRouteRepository;
            _busSubRouteRepositoey = busSubRouteRepositoey;
            _busRouteRelationRepository = busRouteRelationRepository;
            _cityBusProxy = cityBusProxy;
            _mapper = mapper;
        }

        /// <summary>
        /// 新增公車路線/附屬路線資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public async Task<bool> AddBusRouteAsync(string city)
        {
            var res = 0;
            var models = await _cityBusProxy.GetRouteAsync(city);

            //route
            //var routes = _mapper.Map<IEnumerable<BusRoute>>(models);

            //res += await _busRouteRepository.AddAsync(routes);

            ////route-operator mapping
            //var operators = models.SelectMany(x => x.Operators.Select(c => new BusRouteOperator
            //{
            //    RouteId = long.Parse(x.RouteID),
            //    OperatorId = long.Parse(c.OperatorID)
            //}));

            //await _busRouteRelationRepository.AddAsync(operators);

            //subroute
            var subroutes = models.SelectMany(x => x.SubRoutes.Select(c =>
            {
                var item = _mapper.Map<BusSubRoute>(c);
                item.RouteId = long.Parse(x.RouteID);
                return item;
            }));

            res += await _busSubRouteRepositoey.AddAsync(subroutes);

            var subRouteOperators = subroutes.Where(x => x.Direction == 1)
                .SelectMany(x => x.OperatorIds.Select(operatorId =>
                new BusSubRouteOperator
                {
                    SubRouteID = x.SubRouteID,
                    OperatorID = operatorId
                }));

            await _busRouteRelationRepository.AddAsync(subRouteOperators);

            return true;
        }

        /// <summary>
        /// 新增公車業者資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public async Task<bool> AddBusOperator(string city)
        {
            var models = await _cityBusProxy.GetBusOperator(city);
            var operators = _mapper.Map<List<BusOperator>>(models);
            var res = await _busOperatorRepository.AddAsync(operators);
            return res == operators.Count;
        }
    }
}