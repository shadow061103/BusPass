using BusPass.Repository.Infrastructure.Helpers;
using BusPass.Repository.Interfaces;
using BusPass.Repository.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BusPass.Repository.Implements
{
    public class BusSubRouteRepositoey : IBusSubRouteRepositoey
    {
        private readonly IDatabaseHelper _databaseHelper;

        public BusSubRouteRepositoey(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<int> AddAsync(BusSubRoute busSubRoute)
        {
            using (var conn = _databaseHelper.GetBusPassConnection())
            {
                var sql = GetInsertSqlCommand();

                return await conn.ExecuteAsync(sql, busSubRoute);
            }
        }

        public async Task<int> AddAsync(IEnumerable<BusSubRoute> busSubRoutes)
        {
            using (var conn = _databaseHelper.GetBusPassConnection())
            {
                var sql = GetInsertSqlCommand();

                return await conn.ExecuteAsync(sql, busSubRoutes);
            }
        }

        private string GetInsertSqlCommand() => @"
                            INSERT INTO [dbo].[BusSubRoute]
                            (
                                [SubRouteID],
                                [SubRouteName],
                                [Direction],
                                [FirstBusTime],
                                [LastBusTime],
                                [HolidayFirstBusTime],
                                [HolidayLastBusTime],
                                [RouteId]
                            )
                            VALUES
                            (
                                @SubRouteID,
                                @SubRouteName,
                                @Direction,
                                @FirstBusTime,
                                @LastBusTime,
                                @HolidayFirstBusTime,
                                @HolidayLastBusTime,
                                @RouteId
                             );";
    }
}