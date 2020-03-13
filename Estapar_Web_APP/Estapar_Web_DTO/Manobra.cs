using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estapar_Web_DTO
{
    public class Manobra
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Escolha um manobrista!")]
        public Manobrista manobrista { get; set; }

        [Required(ErrorMessage = "Escolha um veículo!")]
        public Veiculo veiculo { get; set; }

        [Required(ErrorMessage = "Preencha a data do estacionamento!")]
        [DisplayName("Data e Hora do Estacionamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string data { get; set; }

        [Required(ErrorMessage = "Preencha a data do termino do estacionamento!")]
        [DisplayName("Data e Hora do Término")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string dataTerm { get; set; }
    }
}
