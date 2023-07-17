using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuadroKanban.Data;
using QuadroKanban.Data.DTO;
using QuadroKanban.Model;
using QuadroKanban.Services;

namespace QuadroKanban.Controller;

[ApiController]
[Route("[Controller]")]
[Authorize]
[ServiceFilter(typeof(ChangeLogFilter))]
public class CardsController: ControllerBase
{
    private CardService _service;
    private CardContext _context;

    public CardsController(CardService service, CardContext context)
    {
        _service = service;
        _context = context;
    }

    // ======================================================================
    [HttpPost]
    public IActionResult CadastraCard(CreateCardDto dto)
    {
        return _service.Cadastra(dto);
    }

    
    [HttpGet]
    public IActionResult RecuperaCards([FromQuery] int skip = 0, [FromQuery] int take = int.MaxValue)
    {
        return _service.RecuperaCards(skip, take);
    }

    
    [HttpGet("{id}")]
    public IActionResult RecuperaCardsPorId(int id)
    {
        return _service.RecuperaCardPorId(id);
    }

    
    [HttpPut("{id}")]
    public IActionResult AlteraCard(int  id, [FromBody] UpdateCardDto dto)
    {
        return _service.AlteraCard(id, dto);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteCard(int id)
    {
        return _service.DeleteCard(id);
    }
}
