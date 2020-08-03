using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Mathy.API.Model;
using Microsoft.Extensions.Configuration;

namespace Mathy.API.Repository.Classes
{
    public class AutorRepository : IAutorRepository
    {

        IConfiguration _configuration;

        public AutorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnection()
        {
            var connection = _configuration.GetSection("Conexao").Value;
            return connection;
        }

        public Autor Get()
        {
            var connectionString = this.GetConnection();
            Autor autor = new Autor();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM AUTOR";
                    autor = con.Query<Autor>(query).FirstOrDefault();
                }
                finally
                {
                    con.Close();
                }
               
            }

            return autor;

        }
    }
}
