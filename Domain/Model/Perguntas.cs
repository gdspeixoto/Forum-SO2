using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Pergunta
    {
        public int Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string NomePessoa { get; set; }
        public string Titulo { get; set; }
        public string TextoPergunta { get; set; }
        public List<Resposta> Respostas { get; set; }
        public int Ativo { get; set; }

        public Pergunta()
        {
            Respostas = new List<Resposta>();
        }
    }
}
