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
    public class PessoaRepositorio : Contexto, IRepositorio<Pessoa>
    {

        public string Salvar(Pessoa entidade)
        {
            string retorno = "";

            if (entidade.Id <= 0)
            {
                retorno = Inserir(entidade);
            }

            if (entidade.Id > 0)
            {
                retorno = Alterar(entidade);
            }

            return retorno;
        }

        private string Inserir(Pessoa entidade)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@Nome", entidade.Nome);
                AdicionarParametros("@Idade", entidade.Idade);
                AdicionarParametros("@Email", entidade.Email);
                AdicionarParametros("@Login", entidade.Login);
                string retorno = ExecutarComando(CommandType.StoredProcedure, "uspPessoaInserir").ToString();
                return retorno;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string Alterar(Pessoa entidade)
        {
            return null;
        }

        public IEnumerable<Pessoa> ListarTodos()
        {
            try
            {
                DataTable dtPessoa = new DataTable();
                IList<Pessoa> pessoas = new List<Pessoa>();
                dtPessoa = ExecutarConsulta(CommandType.StoredProcedure, "uspPessoaListar");
                foreach (DataRow linha in dtPessoa.Rows)
                {
                    Pessoa pessoa = new Pessoa();
                    pessoa.Id = Convert.ToInt32(linha["Id"]);
                    pessoa.Nome = linha["Nome"].ToString();
                    pessoa.Idade = Convert.ToInt32(linha["Idade"]);
                    pessoa.Email = linha["Email"].ToString();
                    pessoa.Login = linha["Login"].ToString();

                    pessoas.Add(pessoa);
                }

                return pessoas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
