using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trabFinal.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o usuário")]
        [Display(Name = "Usuário:")]
        public String Username { get; set; }

        [Required(ErrorMessage = "E-mail inválido")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail:")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Informe a senha:")]
        [DataType(DataType.Password)]
        public String Senha { get; set; }

        [Required(ErrorMessage = "Informe o nível:")]
        [Display(Name = "Nível:")]
        public String Nivel { get; set; }


    }
}