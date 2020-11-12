using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supermercado.Models;
using Supermercado3.Negocios;
using Supermercado3.Negocios.Interfaces;
using Supermercado3.Negocios.Negocios;
using Supermercado3.Web.Models;

namespace Supermercado3.Web.Controllers
{
    public class PessoaController : Controller
    {
        private IPessoaNegocios _pessoaNegocios = new PessoaNegocios();
        [HttpGet]
        public ActionResult Cadastro()
        {
            var pessoa = new PessoaViewModel();
            return View(pessoa);

        }
        [HttpPost]
        public ActionResult Cadastro(PessoaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var pessoa = new Pessoa()
            {
                Nome = model.Nome,
                Idade = model.Idade,
                Email = model.Email,
                Login = model.Login
            };
            _pessoaNegocios.Salvar(pessoa);
            return RedirectToAction("Resultado", pessoa);
        }

        public ActionResult VerCadastros()
        {
            var pessoas = _pessoaNegocios.ListarTodos();

                return View(pessoas);
           
        }

        public ActionResult Resultado(PessoaViewModel pessoa)
        {
            return View(pessoa);
        }

        public ActionResult LoginUnico(string Login)
        {
            
                var pessoas = _pessoaNegocios.ListarTodos();
                return Json(pessoas.All(x => x.Login.ToLower() != Login.ToLower()), JsonRequestBehavior.AllowGet);

            

        }
    }
}