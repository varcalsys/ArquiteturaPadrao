using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Contracts
{
    public interface IAppServiceBase<T> where T: class
    {
        void Registrar(T entity);
        void Alterar(T entity);
        IQueryable<T> BuscarTodos();
        T BuscarPorId(int id);
    }
}
