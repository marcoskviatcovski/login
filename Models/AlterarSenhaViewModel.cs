using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class AlterarSenhaViewModel
    {
        [Required]
        private string SenhaAtual { get; set; } 
        [Required]
        public string NovaSenha { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        [Compare(nameof(NovaSenha), ErrorMessage = "as senhas nao conferem")]
        public string ConfirmacaoSenha { get; set; }
    }
}