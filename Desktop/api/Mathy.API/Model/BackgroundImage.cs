using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mathy.API.Model
{
    public class BackgroundImage
    {
        public int ImageId { get; set; }
        public DateTime HraInicioImagem { get; set; }
        public DateTime HraFimImagem { get; set; }

        public BackgroundImage()
        {

        }
    }
}
