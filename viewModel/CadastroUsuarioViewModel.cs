using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Views
{
    public class CadastroUsuarioViewModel
    {

        [Required(ErrorMessage = "informe o nome fazendo o favor")]
        public string Nome { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare(nameof(Senha), ErrorMessage = "a senha e a ConfirmacaoSenha não são iguais")]
        public string ConfirmacaoSenha { get; set; }
    }
}