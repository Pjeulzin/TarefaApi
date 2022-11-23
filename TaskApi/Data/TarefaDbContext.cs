
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TarefaApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TarefaApi.Data
{
    public class TarefaDbContext : DbContext
    {
        public TarefaDbContext(DbContextOptions<TarefaDbContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
