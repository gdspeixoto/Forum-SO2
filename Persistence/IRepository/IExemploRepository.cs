using Domain.Filter;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IExemploRepository
    {
        public Task<Exemplo[]> GETAllExemplo(int pulo, int limite, ExemploFiltro filtro);
    }
}
