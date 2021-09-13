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
    public class OrderItemAppService
    {
        string connectionString = null;

        public OrderItemAppService(string conn)
        {
            connectionString = conn;
        }

        public List<OrderItem> GetAll()
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                return context.Query<OrderItem>("SELECT * FROM OrderItems").ToList();
            }
        }

        public OrderItem GetByOrderId(int id)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                return context.Query<OrderItem>("SELECT * FROM OrderItems WHERE OrderId = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(OrderItem orderItem)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO OrderItems (OrderId, ItemId) VALUES" +
                    "(@OrderId, @ItemId)";
                context.Execute(sqlQuery, orderItem);
            }
        }

        public void UpdateOrderId(OrderItem orderItem)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE OrderItems SET OrderId = @OrderId WHERE ItemId = @ItemId";
                context.Execute(sqlQuery, orderItem);
            }
        }

        public void DeleteByOrderId(int id)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM OrderItems WHERE OrderId = @id";
                context.Execute(sqlQuery, new { id });
            }
        }
    }
}
