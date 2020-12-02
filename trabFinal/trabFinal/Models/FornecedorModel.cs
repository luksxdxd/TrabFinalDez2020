using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabFinal.Models
{
    public class FornecedorModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Empresa:")]
        [Required(ErrorMessage ="Informe o nome da empresa")]
        public String Empresa { get; set; }

        [Display(Name ="Cartegoria:")]
        [Required(ErrorMessage ="Informe a cartegorai")]
        public String Cartegoria { get; set; }

        [Display(Name ="Endereço:")]
        [Required(ErrorMessage ="Informe o endereço")]
        public String Endereco { get; set; }

        public virtual ICollection<ProdutoModel> Produtoss { get; set; }
    }
}