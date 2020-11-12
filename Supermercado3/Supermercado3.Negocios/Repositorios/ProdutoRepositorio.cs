using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermercado3.AcessoDados;
using Supermercado3.AcessoDados.Interface;

namespace Supermercado3.Negocios.Repositorios
{
    public class ProdutoRepositorio : Contexto, IRepositorio<Produto>
    {

        public string Salvar(Produto entidade)
        {
            string retorno = "";

            if (entidade.Codigo <= 0)
            {
                retorno = Inserir(entidade);
            }

            if (entidade.Codigo > 0)
            {
                retorno = Alterar(entidade);
            }

            return retorno;
        }

        private string Inserir(Produto entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@Nome", entidade.Nome);
                AdicionarParametros("@Categoria", entidade.Categoria);
                AdicionarParametros("@Marca", entidade.Marca);
                AdicionarParametros("@Preco", entidade.Preco);
                string retorno = ExecutarComando(CommandType.StoredProcedure, "uspProdutoInserir").ToString();
                return retorno;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string Alterar(Produto entidade)
        {
            return null;
        }

        public IEnumerable<Produto> ListarTodos()
        {
            try
            {
                DataTable dtProduto = new DataTable();
                IList<Produto> produtos = new List<Produto>();
                dtProduto = ExecutarConsulta(CommandType.StoredProcedure, "uspProdutoListar");
                foreach (DataRow linha in dtProduto.Rows)
                {
                    Produto produto = new Produto();
                    produto.Codigo = Convert.ToInt32(linha["Id"]);
                    produto.Nome = linha["Nome"].ToString();
                    produto.Categoria = linha["Categoria"].ToString();
                    produto.Marca = linha["Marca"].ToString();
                    produto.Preco = linha["Preco"].ToString();

                    produtos.Add(produto);
                }

                return produtos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
