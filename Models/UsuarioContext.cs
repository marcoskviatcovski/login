using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext() : base("Usuarios")
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
    }

}