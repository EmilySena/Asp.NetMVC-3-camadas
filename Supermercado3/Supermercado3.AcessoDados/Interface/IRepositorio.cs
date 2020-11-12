using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado3.AcessoDados.Interface
{
    public interface IRepositorio<T> where T : class
    {
        string Salvar(T entidade);
        IEnumerable<T> ListarTodos();
        
    }
}
