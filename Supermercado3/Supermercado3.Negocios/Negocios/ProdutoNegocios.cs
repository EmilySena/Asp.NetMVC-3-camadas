using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermercado3.Negocios.Interfaces;
using Supermercado3.Negocios.Repositorios;

namespace Supermercado3.Negocios.Negocios
{
    public class ProdutoNegocios : ProdutoRepositorio, IProdutoNegocios
    {
        public Produto ListarProdutoCategoria(string param)
        {
            var produto = ListarTodos().FirstOrDefault(x => x.Categoria == param);

            return produto;
        }
    }
}
