using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IPerguntasRepository
    {
        public Task<Pergunta[]> GETAllPerguntas();
        public Task<Pergunta> GetIdPergunta(int id);
        public Task<Pergunta> CreatePergunta(Pergunta pergunta);
    }
}
