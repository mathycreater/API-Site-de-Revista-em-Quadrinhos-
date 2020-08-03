using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mathy.API.Model
{
    public class Autor
    {
        public string Nome { get; set; }
        public string ImgLinkAutor { get; set; }
        public string Sobre { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }

        public Autor()
        {

        }
    }
}
