using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supermercado3.Negocios;
using Supermercado3.Negocios.Interfaces;
using Supermercado3.Negocios.Negocios;

namespace Supermercado3.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoNegocios _produtoNegocios = new ProdutoNegocios();
        public ActionResult Index()
        {
                var produtos = _produtoNegocios.ListarTodos();
                var maisComprados = produtos.Take(3);
                var todasAsCategorias = produtos.Select(x => x.Categoria).Distinct().ToList();
                ViewBag.Categorias = todasAsCategorias;
                return View(maisComprados);


        }

        public ActionResult TodosOsProdutos()
        {
            var produtos = _produtoNegocios.ListarTodos();

                return View(produtos);
            
        }

        public ActionResult MostraProduto(int codigo, string nome, string categoria)
        {
            var produtos = _produtoNegocios.ListarTodos();
            
                return View(produtos.FirstOrDefault(x => x.Codigo == codigo));

        }

        public ActionResult MostraCategoria(string categoria)
        {
            var produtos = _produtoNegocios.ListarTodos();
            var categoriaEspecifica = produtos.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();
                ViewBag.Categoria = categoria;
                return View(categoriaEspecifica);

        }
    }
}