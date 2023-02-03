namespace ApiDradAndDrop.Interfaces;

public interface IService<T>
{
    Task<List<T>> ListarAsync();
    Task IncluirAsync(T obj);
    Task<T> AtualizarAsync(T obj);
    Task ExcluirAsync(T obj);
}