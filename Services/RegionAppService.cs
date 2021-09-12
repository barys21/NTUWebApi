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
    public class RegionAppService
    {
        string connectionString = null;

        public RegionAppService(string conn)
        {
            connectionString = conn;
        }

        public List<Region> GetAll()
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                return context.Query<Region>("SELECT * FROM Regions").ToList();
            }
        }

        public Region GetById (int id)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                return context.Query<Region>("SELECT * FROM Regions WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Region region)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Regions (Name, CityId) VALUES(@Name, @CityId)";
                context.Execute(sqlQuery, region);
            }
        }

        public void Update(Region region)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Regions SET Name = @Name, CityId = @CityId WHERE Id = @Id";
                context.Execute(sqlQuery, region);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Regions WHERE Id = @id";
                context.Execute(sqlQuery, new { id });
            }
        }
    }
}
