using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathy.API.Repository;
using Microsoft.AspNetCore.Mvc;
namespace Mathy.API.Controllers
{
    [Route("api/[Controller]")]
    public class GetImagesByCategoryId : Controller
    {
        private readonly IImagensRepository _repository;

        public GetImagesByCategoryId(IImagensRepository repository)
        {
            _repository = repository;
            
        }

        [HttpGet("{Id}")]
        public IActionResult GetByCategoryId(int Id)
        {
            try
             {
                var imagens = _repository.GetImagesByCategoryId(Id);

                if(imagens.Count == 0){
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