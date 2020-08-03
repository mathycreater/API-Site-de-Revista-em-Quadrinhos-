using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mathy.API.Model
{
    public class Imagens
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Link { get; set; }

        public DateTime DtInicioPub { get; set; }

        public Imagens()
        {
           
        }
    }

}
