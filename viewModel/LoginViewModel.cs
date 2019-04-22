using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.viewModel
{
    public class LoginViewModel
    {
        [HiddenInput]
        public string urlRetorno { get; set; }
        [Required(ErrorMessage = "informe o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "informe a senha")]
        public string Senha { get; set; }
    }
}