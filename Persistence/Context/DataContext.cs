using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Persistence.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Exemplo> DB_Exemplo { get; set; } //Este objeto relaciona-se a tabela do banco de dados

        public DataContext(DbContextOptions<DataContext> options)
               : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Exemplo_ModelCreating(builder);
        }

        /// <summary>
        /// Metodo que define a estrutura da tabela exemplo
        /// </summary>
        private void Exemplo_ModelCreating(ModelBuilder builder)
        {
            builder.Entity<Exemplo>().ToTable("Exemplo");//Indica o nome da tabela
            builder.Entity<Exemplo>().HasKey(x => x.ID);//Indicação da chave primária da tabela
            builder.Entity<Exemplo>().Property(x => x.ID).HasColumnName("ID");//Indica o nome da coluna da tabela
            builder.Entity<Exemplo>().Property(x => x.ID).IsRequired();//Torna obrigatório o campo ser preenchido (NOT NULL)
            
            builder.Entity<Exemplo>().Property(x => x.Nome).HasColumnName("Nome");
            builder.Entity<Exemplo>().Property(x => x.Nome).IsRequired();
            builder.Entity<Exemplo>().Property(x => x.Nome).HasMaxLength(200);//Indica o tamanho maximo da coluna da tabela

            builder.Entity<Exemplo>().Property(x => x.Valor).HasColumnName("Valor");
            builder.Entity<Exemplo>().Property(x => x.Valor).IsRequired();

            builder.Entity<Exemplo>().Property(x => x.Ativo).HasColumnName("Ativo");
            builder.Entity<Exemplo>().Property(x => x.Ativo).IsRequired();

            //Cria registro inicias na tabela exemplo
            builder.Entity<Exemplo>()
            .HasData(new List<Exemplo>()
                {
                    new Exemplo(1,"Exemplo 1",10,true),
                    new Exemplo(2,"Exemplo 2",20,false),
                }
            );
        }
    }
}
