using Microsoft.EntityFrameworkCore;
using ApiDradAndDrop.Interfaces;
using ApiDradAndDrop.Models;
using ApiDradAndDrop.Conexao;

namespace ApiDradAndDrop.Repositories;

public class PersonagensRepositorie : IService<Personagens>
{
    private Context context;
    public PersonagensRepositorie()
    {
        context = new Context();

    }

     public async Task<List<Personagens>> ListarAsync()
    {
        return await context.personagens.ToListAsync();
    }

    public async Task IncluirAsync(Personagens personagens)
    {
        context.personagens.Add(personagens);
        await context.SaveChangesAsync();
    }

    public async Task<Personagens> AtualizarAsync(Personagens personagens)
    {
        context.Entry(personagens).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return personagens;
    }

    public async Task ExcluirAsync(Personagens personagens)
    {
        var obj = await context.personagens.FindAsync(personagens.Id);
        if (obj is null) throw new Exception("Personagem não localizado.");
        context.personagens.Remove(obj);
        await context.SaveChangesAsync();
    }
}