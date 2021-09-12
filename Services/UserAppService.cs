
using Dapper;
using Microsoft.IdentityModel.Tokens;
using NTUWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace NTUWebApi.Services
{
    public class UserAppService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "kenes", LastName = "kuanyshov", Username = "kenes.kuanyshov", Password = "123qwe*" }
        };
        const string KEY = "mysupersecret_secretkey!123";
        string connectionString = null;

        public UserAppService(string conn)
        {
            connectionString = conn;
        }

        

        public User Authenticate(string username, string password)
        {
            User user;

            using (IDbConnection context = new SqlConnection(connectionString))
            {
                user = context.Query<User>("SELECT * FROM Users WHERE Username = @username AND Password == password", new {username, password }).SingleOrDefault();
            }

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public List<User> GetAll()
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                return context.Query<User>("SELECT * FROM Users").ToList();
            }
        }

        public void Create(User user)
        {
            using (IDbConnection context = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (FirstName, LastName, Username, Password) VALUES" +
                               "(@FirstName, @LastName, @Username, @Password)";
                context.Execute(sqlQuery, user);
            }
        }
    }
}
