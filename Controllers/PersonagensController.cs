using ApiDradAndDrop.Interfaces;
using ApiDradAndDrop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiDradAndDrop.Controllers;

[Route("personagens")]
public class PersonagensController : ControllerBase
{
    private IService<Personagens> _service;

    public PersonagensController(IService<Personagens> service)
    {
        _service = service;
    }
    
     [HttpGet("")]
     public async Task<IActionResult> Index()
    {
        var personagens = await _service.ListarAsync();
        return StatusCode(200, personagens);
    }

    [HttpGet("{id}")]
   
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var personagem = (await _service.ListarAsync()).Find(p => p.Id == id);

        return StatusCode(200, personagem);
    }

    [HttpPost("")]
  
    public async Task<IActionResult> Create([FromBody] Personagens personagens)
    {
        await _service.IncluirAsync(personagens);
        return StatusCode(201, personagens);
    }

    [HttpPut("{id}")]
  
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Personagens personagens)
    {
        if (id != personagens.Id)
        {
            return StatusCode(400, new
            {
                Mensagem = "O Id precisa bater com o id da URL"
            });
        }

        var persoDb = await _service.AtualizarAsync(personagens);

        return StatusCode(200, persoDb);
    }

    [HttpDelete("{id}")]
  
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var persoDb = (await _service.ListarAsync()).Find(p => p.Id == id);
        if (persoDb is null)
        {
            return StatusCode(404, new
            {
                Mensagem = "O personagem informado não existe"
            });
        }

        await _service.ExcluirAsync(persoDb);

        return StatusCode(204);
    }
}