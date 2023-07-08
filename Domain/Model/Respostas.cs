﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Resposta
    {
        public int Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string Nome { get; set; }
        public string TextoResposta { get; set; }
    }
}
