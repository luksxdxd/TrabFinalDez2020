using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabFinal.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Nome do produto:")]
        [Required(ErrorMessage ="Insira o nome do produto")]
        public String Produto { get; set; }

        [Display(Name ="Descrição:")]
        public String Descricao { get; set; }

        public int? FornecedorId { get; set; }
        public FornecedorModel fornEmpre { get; set;  }
    }
}