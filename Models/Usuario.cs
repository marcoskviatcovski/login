using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Login.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
            [Key]
            [Required]
            public int Id { get; set; }
            [Required]
            public string Nome { get; set; }
            [Required]
            public string Login { get; set; }
            [Required]
            public string Senha { get; set; }

        }
  }
