using System.Collections.Generic;
using Mathy.API.Model;

namespace Mathy.API.Repository
{
    public interface ICategoriaRepository
    {
         List<Categorias> Get();
         Categorias GetById(int Id);
          List<Categorias> GetCategoriesByImageId(int Id);

    }
}