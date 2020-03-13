using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estapar_Web_DTO
{
    public class Log
    {
        [DisplayName("Data e Hora")]
        public string data { get; set; }

        [DisplayName("Mensagem")]
        public string msg { get; set; }
    }
}
