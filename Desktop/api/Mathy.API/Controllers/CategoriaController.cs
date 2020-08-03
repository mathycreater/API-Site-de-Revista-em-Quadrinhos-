using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathy.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mathy.API.Controllers
{
    [Route("api/[Controller]")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
            
        }

        [HttpGet()]
        public IActionResult Get()
        {
            try
             {
                var categorias = _repository.Get();
                return new ObjectResult(categorias);


            }catch(Exception e)
            {
                return StatusCode(500, new { erro = "Falha no servidor! Tente novamente mais tarde" });
            }
        }


        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
             {
                var categorias = _repository.GetById(Id);

                if(categorias == null){
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