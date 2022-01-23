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
    public class BusOperatorRepository : IBusOperatorRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public BusOperatorRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<int> AddAsync(BusOperator busOperator)
        {
            using (var conn = _databaseHelper.GetBusPassConnection())
            {
                var sql = GetInsertSqlCommand();

                return await conn.ExecuteAsync(sql, busOperator);
            }
        }

        public async Task<int> AddAsync(IEnumerable<BusOperator> busOperators)
        {
            using (var conn = _databaseHelper.GetBusPassConnection())
            {
                var sql = GetInsertSqlCommand();

                return await conn.ExecuteAsync(sql, busOperators);
            }
        }

        private string GetInsertSqlCommand() => @"
                            INSERT INTO [dbo].[BusOperator]
                            (
                                [OperatorID],
                                [OperatorName],
                                [OperatorPhone],
                                [OperatorUrl],
                                [OperatorNo],
                                [OperatorCode]
                            )
                            VALUES
                            (
                                @OperatorID,
                                @OperatorName,
                                @OperatorPhone,
                                @OperatorUrl,
                                @OperatorNo,
                                @OperatorCode
                            );

";
    }
}