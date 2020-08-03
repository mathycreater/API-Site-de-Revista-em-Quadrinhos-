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
    public class CategoriaRepository : ICategoriaRepository
    {
         IConfiguration _configuration;

        public CategoriaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnection()
        {
            var connection = _configuration.GetSection("Conexao").Value;
            return connection;
        }

        public List<Categorias> Get()
        {
            var connectionString = this.GetConnection();
            List<Categorias> lista = new List<Categorias>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * from Categorias";
                    lista = con.Query<Categorias>(query).ToList();
                }
                finally
                {
                    con.Close();
                }
               
            }

            return lista;

        }


        public Categorias GetById(int Id)
        {
            var connectionString = this.GetConnection();
            Categorias categorias = new Categorias();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * from Categorias";
                    categorias = con.Query<Categorias>(query).FirstOrDefault(x => x.Id == Id);
                    //=> é como se falasse o seguinte Categoria => x (Como se fosse uma seta) LAMBDA FUNCTIONS
                }
                finally
                {
                    con.Close();
                }
               
            }

            return categorias;

        }


        public List<Categorias> GetCategoriesByImageId(int Id)
        {
            var connectionString = this.GetConnection();
            List<Categorias> lista = new List<Categorias>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = $@"select c.* 
                                    from Categorias c
                                    inner join CategoriaImagem ci on ci.CategoriaId = c.Id
                                    inner join Imagens i on i.Id = ci.ImagemId
                                    where i.id = {Id}";
                    lista = con.Query<Categorias>(query).ToList();
                }
                finally
                {
                    con.Close();
                }
               
            }

            return lista;

        }
    }
}