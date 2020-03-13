using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estapar_Web_DTO
{
    public class Manobrista
    {
        [DisplayName("Nome do Manobrista")]
        [Required(ErrorMessage = "Preencha o nome do manobrista!")]
        [DataType(DataType.Text)]
        [MaxLength(200)]
        public string nome { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Preencha o CPF do manobrista!")]
        [StringLength(14, MinimumLength = 14)]
        [RegularExpression(@"[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}", ErrorMessage = "Formato do CPF inválido! (XXX.XXX.XXX-XX)")]
        public string cpf { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Preencha a data de nascimento do manobrista!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string dataNasc { get; set; }
    }
}
