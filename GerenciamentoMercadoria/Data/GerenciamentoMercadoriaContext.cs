using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GerenciamentoMercadoria.Models;

    public class GerenciamentoMercadoriaContext : DbContext
    {
        public GerenciamentoMercadoriaContext (DbContextOptions<GerenciamentoMercadoriaContext> options)
            : base(options)
        {
        }

        public DbSet<Mercadoria> Mercadoria { get; set; } = default!;
        public DbSet<EntradaSaidaMercadoria> entradaSaidaMercadorias { get; set; } = default!;
    }
