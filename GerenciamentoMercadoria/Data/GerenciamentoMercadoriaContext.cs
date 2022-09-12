using GerenciamentoMercadoria.Models;
using Microsoft.EntityFrameworkCore;

public class GerenciamentoMercadoriaContext : DbContext
{
    public GerenciamentoMercadoriaContext (DbContextOptions<GerenciamentoMercadoriaContext> options)
        : base(options)
    {
    }

    public DbSet<Mercadoria> Mercadoria { get; set; } = default!;
    public DbSet<EntradaMercadoria> EntradaMercadoria { get; set; } = default!;
    public DbSet<SaidaMercadoria> SaidaMercadoria { get; set; } = default!;
}
