using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuadroKanban.Model;

namespace QuadroKanban.Data;

public class UsuarioContext: IdentityDbContext<Usuario>
{
    public DbSet<Usuario>? Ususarios { get; set; }

    public UsuarioContext(DbContextOptions<UsuarioContext> opts): base(opts){
        
    }
}
