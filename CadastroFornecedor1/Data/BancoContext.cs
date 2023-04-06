using CadastroFornecedor1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace CadastroFornecedor.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { }

        public DbSet<FornecedorModel> Fornecedores { get; set; }

    }
}
