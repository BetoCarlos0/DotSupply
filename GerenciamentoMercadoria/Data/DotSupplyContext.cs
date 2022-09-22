using DotSupply.Models;
using Microsoft.EntityFrameworkCore;

public class DotSupplyContext : DbContext
{
    public DotSupplyContext (DbContextOptions<DotSupplyContext> options)
        : base(options)
    {
    }

    public DbSet<Mercadoria> Mercadoria { get; set; } = default!;
    public DbSet<EntradaMercadoria> EntradaMercadoria { get; set; } = default!;
    public DbSet<SaidaMercadoria> SaidaMercadoria { get; set; } = default!;
}
