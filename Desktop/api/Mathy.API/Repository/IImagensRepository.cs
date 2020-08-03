using System.Collections.Generic;
using Mathy.API.Model;

namespace Mathy.API.Repository
{
    public interface IImagensRepository
    {
         List<Imagens> Get();
         Imagens GetById(int Id);

          List<Imagens> GetImagesByCategoryId(int CategoryId);

          Imagens GetBackgroundImage();

    }
}