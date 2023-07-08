using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class PerguntaDto
    {
        public int Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string NomePessoa { get; set; }
        public string Titulo { get; set; }
        public string TextoPergunta { get; set; }
        public List<RespostaDto> Respostas { get; set; }

        public PerguntaDto()
        {
            Respostas = new List<RespostaDto>();
        }
    }
}
