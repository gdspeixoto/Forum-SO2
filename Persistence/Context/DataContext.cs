using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
               : base(options)
        {}

        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
    }
}
