using ApiDradAndDrop.Interfaces;
using ApiDradAndDrop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiDradAndDrop.Controllers;

[Route("lista")]
public class ListaController : ControllerBase
{
    private IService<Lista> _service;

    public ListaController(IService<Lista> service)
    {
        _service = service;
    }
    
     [HttpGet("")]
     public async Task<IActionResult> Index()
    {
        var lista = await _service.ListarAsync();
        return StatusCode(200, lista);
    }

    [HttpGet("{id}")]
   
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var listas = (await _service.ListarAsync()).Find(l => l.Id == id);

        return StatusCode(200, listas);
    }

    [HttpPost("")]
  
    public async Task<IActionResult> Create([FromBody] Lista lista)
    {
        await _service.IncluirAsync(lista);
        return StatusCode(201, lista);
    }

    [HttpPut("{id}")]
  
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Lista lista)
    {
        if (id != lista.Id)
        {
            return StatusCode(400, new
            {
                Mensagem = "O Id precisa bater com o id da URL"
            });
        }

        var listaDb = await _service.AtualizarAsync(lista);

        return StatusCode(200, listaDb);
    }

    [HttpDelete("{id}")]
  
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var listaDb = (await _service.ListarAsync()).Find(l => l.Id == id);
        if (listaDb is null)
        {
            return StatusCode(404, new
            {
                Mensagem = "A lista informada não existe"
            });
        }

        await _service.ExcluirAsync(listaDb);

        return StatusCode(204);
    }
}