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
    public class ItemAppService
    {
        string connectionString = null;

        public ItemAppService(string conn)
        {
            connectionString = conn;
        }

        public List<Item> GetAll()
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                return context.Query<Item>("SELECT * FROM Items").ToList();
            }
        }

        public Item GetById(int id)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                return context.Query<Item>("SELECT * FROM Items WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Item item)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Items (Name, Price) VALUES(@Name, @Price)";
                context.Execute(sqlQuery, item);
            }
        }

        public void Update (Item item)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Items SET Name = @Name, Price = @Price WHERE Id = @Id";
                context.Execute(sqlQuery, item);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Items WHERE Id = @id";
                context.Execute(sqlQuery, new { id });
            }
        }
    }
}
