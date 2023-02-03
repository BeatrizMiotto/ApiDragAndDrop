using ApiDradAndDrop.Models;

using Microsoft.EntityFrameworkCore;

namespace ApiDradAndDrop.Conexao;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conexao = Environment.GetEnvironmentVariable("DATABASE_URL_BM");
        if (conexao is null) conexao = "Server=localhost;Database=quadro;Uid=root;Pwd='';";
        optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
    }

    public DbSet<Personagens> personagens { get; set; } = default!;
    public DbSet<Lista> lista { get; set; } = default!;

}