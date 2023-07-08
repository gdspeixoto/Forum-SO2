using Domain.Filter;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.IRepository;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ExemploRepository : IExemploRepository
    {
        private readonly DataContext _context;

        public ExemploRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Exemplo[]> GETAllExemplo(int pulo, int limite, ExemploFiltro filtro )
        {
            IQueryable<Exemplo> query = _context.DB_Exemplo.Skip(pulo).Take(limite)
                .Where(x => (filtro.ID == null || x.ID == filtro.ID) &&
                            (string.IsNullOrEmpty(filtro.Nome) || x.Nome.Contains(filtro.Nome)) &&
                            (filtro.Valor == null || x.Valor == filtro.Valor) &&
                            (filtro.Ativo == null || x.Ativo == filtro.Ativo));
              
            query = query.AsNoTracking();
            return await query.ToArrayAsync();
        }
    }
}
