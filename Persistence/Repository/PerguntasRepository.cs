using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class PerguntasRepository : IPerguntasRepository
    {
        private readonly DataContext _context;

        public PerguntasRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Pergunta[]> GETAllPerguntas()
        {
            IQueryable<Pergunta> query = _context.Perguntas
            .Include(r => r.Respostas)
            .Where(x => x.Ativo == 1 && x.Respostas.Any(r => r.Nome != null));

            query = query.AsNoTracking();
            return await query.ToArrayAsync();
        }

        public async Task<Pergunta> GetIdPergunta(int id)
        {
            IQueryable<Pergunta> query = _context.Perguntas
                .Include(r => r.Respostas);

            query = query.OrderBy(r => r.Id).Where(x => x.Ativo == 1 && x.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pergunta> CreatePergunta(Pergunta pergunta)
        {
            var createdReclamacao = _context.Perguntas.Add(pergunta);

            await _context.SaveChangesAsync();

            return createdReclamacao.Entity;
        }
    }
}
