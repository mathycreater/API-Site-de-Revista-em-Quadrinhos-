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
    public class ImagensRepository : IImagensRepository
    {
         IConfiguration _configuration;

        public ImagensRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnection()
        {
            var connection = _configuration.GetSection("Conexao").Value;
            return connection;
        }

        public List<Imagens> Get()
        {
            var connectionString = this.GetConnection();
            List<Imagens> lista = new List<Imagens>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"SELECT Id, Nome, Descricao, Link, DATEADD(HOUR, -3, DtInicioPub) DtInicioPub 
                                from Imagens where DtInicioPub <= GETDATE()";
                    lista = con.Query<Imagens>(query).ToList();
                }
                finally
                {
                    con.Close();
                }
               
            }

            return lista;

        }


        public Imagens GetById(int Id)
        {
            var connectionString = this.GetConnection();
            Imagens Imagens = new Imagens();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                     var query = @"SELECT Id, Nome, Descricao, Link, DATEADD(HOUR, -3, DtInicioPub) DtInicioPub 
                                from Imagens";
                    Imagens = con.Query<Imagens>(query).FirstOrDefault(x => x.Id == Id);
                    //=> é como se falasse o seguinte Imagens => x (Como se fosse uma seta) LAMBDA FUNCTIONS
                }
                finally
                {
                    con.Close();
                }
               
            }

            return Imagens;

        }

        public List<Imagens> GetImagesByCategoryId(int Id)
        {
            var connectionString = this.GetConnection();
            List<Imagens> lista = new List<Imagens>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = $@"select --* 
                                    i.Id, i.Nome, i.Descricao, i.Link, DATEADD(HOUR, -3, DtInicioPub) DtInicioPub
                                    from Imagens i
                                    inner join CategoriaImagem ci on ci.ImagemId = i.Id
                                    inner join Categorias c on c.Id = ci.CategoriaId 
                                    where DtInicioPub <= GETDATE() and c.Id = {Id}";
                    lista = con.Query<Imagens>(query).ToList();
                   
                }
                finally
                {
                    con.Close();
                }
               
            }

            return lista;
        }

        public Imagens GetBackgroundImage()
        {
            var connectionString = this.GetConnection();
            Imagens Imagens = new Imagens();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                     var query = "GetBackground";
                    Imagens = con.Query<Imagens>(query).FirstOrDefault();
                    //=> é como se falasse o seguinte Imagens => x (Como se fosse uma seta) LAMBDA FUNCTIONS
                }
                finally
                {
                    con.Close();
                }
               
            }

            return Imagens;

        }


    }
}