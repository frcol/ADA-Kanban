using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuadroKanban.Data;
using QuadroKanban.Data.DTO;
using QuadroKanban.Model;

namespace QuadroKanban.Controller;

[ApiController]
[Route("[Controller]")]
[Authorize]
[ServiceFilter(typeof(ChangeLogFilter))]
public class CardsController: ControllerBase
{
    private IMapper _mapper;
    private CardContext _context;

    public CardsController(IMapper mapper, CardContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public IActionResult RecuperaCards([FromQuery] int skip = 0, [FromQuery] int take = int.MaxValue)
    {
        return Ok(_context.Cards.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCardsPorId(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CadastraCard(CreateCardDto dto)
    {
        Card card = _mapper.Map<Card>(dto);
        _context.Cards.Add(card);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaCardsPorId), new {id = card.Id}, card);
    }

    [HttpPut("{id}")]
    public IActionResult AlteraCard(int  id, [FromBody] UpdateCardDto dto)
    {
        Card? card = _context.Cards.FirstOrDefault(card => card.Id == id);

        if (card is null) { return NotFound(); }

        _mapper.Map(dto, card);
        _context.SaveChanges();

        return Ok(card);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCard(int id)
    {
        Card? card = _context.Cards.FirstOrDefault(card => card.Id == id);

        if (card is null) { return NotFound(); }

        _context.Cards.Remove(card);
        _context.SaveChanges();

        return Ok(_context.Cards);
    }
}
