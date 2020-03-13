using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estapar_Web_DTO
{
    public class Veiculo
    {
        [DisplayName("Placa")]
        [Required(ErrorMessage = "Preencha a placa do veículo!")]
        [DataType(DataType.Text)]
        [MaxLength(8)]
        public string placa { get; set; }

        [DisplayName("Marca")]
        [Required(ErrorMessage = "Preencha a marca do veículo!")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string marca { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage = "Preencha o modelo do veículo!")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string modelo { get; set; }
    }
}
