using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Supermercado3.Negocios;

namespace Supermercado.Models
{
    public class ProdutoViewModel
    {
        public string Nome { get; set; }
        public string Preco { get; set; }
        public int Codigo { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public ProdutoViewModel()
        {

        }

        public ProdutoViewModel(Produto produto)
        {
            Codigo = produto.Codigo;
            Nome = produto.Nome;
            Categoria = produto.Categoria;
            Marca = produto.Marca;
            Preco = produto.Preco;
        }
    }
}