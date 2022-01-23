using BusPass.Repository.Infrastructure.Helpers;
using BusPass.Repository.Interfaces;
using BusPass.Repository.Models.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Implements
{
    public class BusRouteRelationRepository : IBusRouteRelationRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public BusRouteRelationRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<int> AddAsync(IEnumerable<BusRouteOperator> relations)
        {
            using (var conn = _databaseHelper.GetBusPassConnection())
            {
                var sql = GetInsertRouteRelationSqlCommand();

                return await conn.ExecuteAsync(sql, relations);
            }
        }

        public async Task<int> AddAsync(IEnumerable<BusSubRouteOperator> relations)
        {
            using (var conn = _databaseHelper.GetBusPassConnection())
            {
                var sql = GetInserSubtRouteRelationSqlCommand();

                return await conn.ExecuteAsync(sql, relations);
            }
        }

        private string GetInsertRouteRelationSqlCommand() => @"
                            INSERT INTO [dbo].[BusRouteOperator]
                            (
                                [RouteId],
                                [OperatorId]
                            )
                            VALUES
                            (
                                @RouteId,
                                @OperatorId
                            );
                            ";

        private string GetInserSubtRouteRelationSqlCommand() => @"
                            INSERT INTO [dbo].[BusSubRouteOperator]
                            (
                                [SubRouteID],
                                [OperatorID]
                            )
                            VALUES
                            (
                                @SubRouteID,
                                @OperatorID
                            );
                            ";
    }
}