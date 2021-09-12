using Dapper;
using NTUWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NTUWebApi.Services
{
    public class OrderAppService
    {
        string connectionString = null;

        public OrderAppService(string conn)
        {
            connectionString = conn;
        }

        public List<Order> GetAll()
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                return context.Query<Order>("SELECT * FROM Orders").ToList();
            }
        }

        public Order GetById (int id)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                return context.Query<Order>("SELECT * FROM Orders WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Order order)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Orders (OrderNumber, RegionId , ItemId, Sum) VALUES" +
                    "(@OrderNumber, @RegionId , @ItemId, @Sum)";
                context.Execute(sqlQuery, order);
            }
        }

        public void Update(Order order)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Orders SET OrderNumber = @OrderNumber, RegionId = @RegionId, ItemId = @ItemId, Sum = @Sum";
                context.Execute(sqlQuery, order);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Orders WHERE Id = @id";
                context.Execute(sqlQuery, new { id });
            }
        }
    }
}
