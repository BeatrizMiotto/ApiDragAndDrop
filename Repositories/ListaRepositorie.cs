using Microsoft.EntityFrameworkCore;
using ApiDradAndDrop.Interfaces;
using ApiDradAndDrop.Models;
using ApiDradAndDrop.Conexao;

namespace ApiDradAndDrop.Repositories;

public class ListaRepositorie : IService<Lista>
{
    private Context context;
    public ListaRepositorie()
    {
        context = new Context();

    }

     public async Task<List<Lista>> ListarAsync()
    {
        return await context.lista.ToListAsync();
    }

    public async Task IncluirAsync(Lista lista)
    {
        context.lista.Add(lista);
        await context.SaveChangesAsync();
    }

    public async Task<Lista> AtualizarAsync(Lista lista)
    {
        context.Entry(lista).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return lista;
    }

    public async Task ExcluirAsync(Lista lista)
    {
        var obj = await context.lista.FindAsync(lista.Id);
        if (obj is null) throw new Exception("Lista não localizada.");
        context.lista.Remove(obj);
        await context.SaveChangesAsync();
    }
}