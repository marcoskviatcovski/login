using Login.Models;
using Login.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Login.Models.Usuario;
using Login.Util;
using Login.viewModel;
using System.Security.Claims;

namespace Login.Controllers
{
    public class AutenticacaoController : Controller


    {
        private UsuarioContext db = new UsuarioContext();
        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (db.Usuarios.Count(u => u.Login == viewModel.Login) > 0)
            {
                ModelState.AddModelError("Login", "Esse login já existe");
                return View(viewModel);
            }


            Usuario novoUsuario = new Usuario
            {
                Nome = viewModel.Nome,
                Login = viewModel.Login,
                Senha = hash.GerarHash(viewModel.Senha)
            };
            db.Usuarios.Add(novoUsuario);
            db.SaveChanges();

            return RedirectToAction("index", "home");
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewsModels = new LoginViewModel
            {
                urlRetorno = ReturnUrl
            };
            return View(viewsModels);
        }





        [HttpPost]
        public ActionResult Login(LoginViewModel viewsModels)
        {
            if (!ModelState.IsValid)
            {
                return View(viewsModels);
            };

            var usuario = db.Usuarios.FirstOrDefault(
                u => u.Login == viewsModels.Login);


            if (usuario == null)
            {
                ModelState.AddModelError("login", "falhou na missao");
                return View(viewsModels);
            }

            if (usuario.Senha != hash.GerarHash(viewsModels.Senha))
            {
                ModelState.AddModelError("Senha", "Login ou senha incorreto");
                return View(viewsModels);
            }

            var identity = new ClaimsIdentity(new[]

                {
                new Claim("Login",usuario.Login)
                }, "ApplicationCookie"
                );

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewsModels.urlRetorno) || Url.IsLocalUrl(viewsModels.urlRetorno))
            {
                return Redirect(viewsModels.urlRetorno);
            }
            else
            {
                return RedirectToAction("index", "painel");
            }
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }
    }
}
