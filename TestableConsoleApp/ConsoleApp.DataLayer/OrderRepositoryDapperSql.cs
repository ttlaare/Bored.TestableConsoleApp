using ConsoleApp.Shared.OrderItem;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ConsoleApp.DataLayer
{

    public class OrderRepositoryDapperSql : IOrderItemRepository
    {
        private readonly IDbConnection db;

        public OrderRepositoryDapperSql(string connString)
        {
            this.db = new SqlConnection(connString);
        }

        public List<OrderItem> GetList()
        {
            var sql = @"SELECT OrderItemName Name, Price, OrderItemTypeId Type FROM OrderItems";
            return this.db.Query<OrderItem>(sql).ToList();
        }
    }
}
