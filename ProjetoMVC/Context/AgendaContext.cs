using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Models;

namespace ProjetoMVC.Context;

public class AgendaContext(DbContextOptions<AgendaContext> options) : DbContext(options)
{
    public DbSet<Contato> Contatos { get; set; } = null!;
}