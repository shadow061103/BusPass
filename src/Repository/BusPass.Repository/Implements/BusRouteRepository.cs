using BusPass.Repository.Infrastructure.Helpers;
using BusPass.Repository.Interfaces;
using BusPass.Repository.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using BusPass.Repository.Models.Entities;

namespace BusPass.Repository.Implements
{
    public class BusRouteRepository : IBusRouteRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public BusRouteRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<int> AddAsync(BusRoute busRoute)
        {
            using (var conn = _databaseHelper.GetBusPassConnection())
            {
                var sql = GetInsertSqlCommand();

                return await conn.ExecuteAsync(sql, busRoute);
            }
        }

        public async Task<int> AddAsync(IEnumerable<BusRoute> busRoute)
        {
            using (var conn = _databaseHelper.GetBusPassConnection())
            {
                var sql = GetInsertSqlCommand();

                return await conn.ExecuteAsync(sql, busRoute);
            }
        }

        private string GetInsertSqlCommand() => @"
                            INSERT INTO [dbo].[BusRoute]
                            (
                                [RouteId],
                                [HasSubRoutes],
                                [BusRouteType],
                                [RouteName],
                                [DepartureStop],
                                [DestinationStop],
                                [TicketPriceDescription],
                                [FareBufferZoneDescription],
                                [RouteMapImageUrl],
                                [City],
                                [CityCode],
                                [UpdateTime]
                            )
                            VALUES
                            (
                                @RouteId,
                                @HasSubRoutes,
                                @BusRouteType,
                                @RouteName,
                                @DepartureStop,
                                @DestinationStop,
                                @TicketPriceDescription,
                                @FareBufferZoneDescription,
                                @RouteMapImageUrl,
                                @City,
                                @CityCode,
                                @UpdateTime
                            );";
    }
}