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
        /// 新增公車路線資料
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public async Task<bool> AddBusRouteAsync(string city)
        {
            var res = 0;
            var models = await _cityBusProxy.GetRouteAsync(city);

            //route
            var routes = _mapper.Map<IEnumerable<BusRoute>>(models);

            var temp = routes.Where(c => c.RouteId == 10132);
            res += await _busRouteRepository.AddAsync(routes);

            //route-operator mapping
            var operators = models.SelectMany(x => x.Operators.Select(c => new BusRouteOperator
            {
                RouteId = long.Parse(x.RouteID),
                OperatorId = long.Parse(c.OperatorID)
            }));

            //todo 附屬路線新增跟業者對應
            await _busRouteRelationRepository.AddAsync(operators);

            //subroute
            //var subroutes = _mapper.Map<BusSubRoute>(models.Select(x => x.SubRoutes));
            //res += await _busSubRouteRepositoey.AddAsync(subroutes);
            //operator mapping
            //var totalCount = models.Count + models.Select(x => x.SubRoutes).Count();

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