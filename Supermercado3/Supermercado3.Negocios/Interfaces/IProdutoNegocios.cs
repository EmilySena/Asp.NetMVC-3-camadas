using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermercado3.AcessoDados.Interface;
using Supermercado3.Negocios.Repositorios;

namespace Supermercado3.Negocios.Interfaces
{
    public interface IProdutoNegocios : IRepositorio<Produto>
    {
        Produto ListarProdutoCategoria(string param);
    }
}
