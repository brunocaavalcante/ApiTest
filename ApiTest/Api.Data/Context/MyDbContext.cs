using Api.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
