using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathy.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mathy.API.Controllers
{
    [Route("api/[Controller]")]
    public class ImagensController : Controller
    {
        private readonly IImagensRepository _repository;

        public ImagensController(IImagensRepository repository)
        {
            _repository = repository;
            
        }

        [HttpGet()]
        public IActionResult Get()
        {
            try
             {
                var imagens = _repository.Get();
                return new ObjectResult(imagens);


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
                var imagens = _repository.GetById(Id);

                if(imagens == null){
                    return StatusCode(404, new{ erro = "Nenhum item foi encontrado"});
                }

                return new ObjectResult(imagens);


            }catch(Exception e)
            {
                return StatusCode(500, new { erro = "Falha no servidor! Tente novamente mais tarde" });
            }
        }

    }
}