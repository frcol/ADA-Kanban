using Microsoft.EntityFrameworkCore;
using QuadroKanban.Model;

namespace QuadroKanban.Data;

public class CardContext: DbContext
{
    public DbSet<Card>? Cards { get; set; }

    public CardContext(DbContextOptions<CardContext> options): base(options)
    {
        
    }
}
