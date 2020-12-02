using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using trabFinal.Models;

namespace trabFinal.Context
{
    public class Contexto : DbContext
    {
        public DbSet<LoginModel> logins { get; set; }
        public DbSet<FornecedorModel> fornecedores { get; set; }
        public DbSet<ProdutoModel> produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}