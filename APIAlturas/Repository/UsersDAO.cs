using APIAlturas.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace APIAlturas.Repository
{
    public class UsersDAO
    {
        private IConfiguration _configuration;

        public UsersDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Find(string userID)
        {
            using (var conexao = new SQLiteConnection(
                _configuration.GetConnectionString("ExemploJWT")))
            {
                conexao.Open();

                return conexao.QueryFirstOrDefault<User>(
                    "SELECT UserID, AccessKey " +
                    "FROM Users " +
                    "WHERE UserID = @UserID", new { UserID = userID });
            }
        }
    }
}
