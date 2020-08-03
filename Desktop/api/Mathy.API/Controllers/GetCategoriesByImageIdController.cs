using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathy.API.Repository;
using Microsoft.AspNetCore.Mvc;
namespace Mathy.API.Controllers
{
    [Route("api/[Controller]")]
    public class GetCategoriesByImageId : Controller
    {
        private readonly ICategoriaRepository _repository;

        public GetCategoriesByImageId(ICategoriaRepository repository)
        {
            _repository = repository;
            
        }

        [HttpGet("{Id}")]
        public IActionResult GetByImageId(int Id)
        {
            try
             {
                var categorias = _repository.GetCategoriesByImageId(Id);

                if(categorias.Count == 0){
                    return StatusCode(404, new{ erro = "Nenhum item foi encontrado"});
                }

                return new ObjectResult(categorias);


            }catch(Exception e)
            {
                return StatusCode(500, new { erro = "Falha no servidor! Tente novamente mais tarde" });
            }
        }
    }
}