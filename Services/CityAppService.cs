using Dapper;
using Microsoft.AspNetCore.Mvc;
using NTUWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NTUWebApi.Services
{
    public class CityAppService
    {
        string connectionString = null;

        public CityAppService(string conn)
        {
            connectionString = conn;
        }

        public List<City> GetAll()
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                return context.Query<City>("SELECT * FROM Cities").ToList();
            }
        }

        public City GetById(int id)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                return context.Query<City>("SELECT * FROM Cities WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(City city)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Cities (Name) VALUES(@Name)";
                context.Execute(sqlQuery, city);
            }
        }

        public void Update(City city)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Cities SET Name = @Name WHERE Id = @Id";
                context.Execute(sqlQuery, city);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Cities WHERE Id = @id";
                context.Execute(sqlQuery, new { id });
            }
        }
    }
}
