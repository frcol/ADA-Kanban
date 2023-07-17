using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadroKanban.Data;
using QuadroKanban.Data.DTO;
using QuadroKanban.Model;

namespace QuadroKanban.Services;

public class CardService
{
    private IMapper _mapper;
    private CardContext _context;

    public CardService(IMapper mapper, CardContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public IActionResult Cadastra(CreateCardDto dto)
    {
        try
        {
            Card card = _mapper.Map<Card>(dto);
            _context.Cards?.Add(card);
            _context.SaveChanges();

            if (card is not null)
            {
                return new CreatedAtActionResult("RecuperaCardsPorId", "Cards", new { id = card.Id }, card);
            }
            else
            {
                return new BadRequestObjectResult("Card não cadastrado");
            }
        }
        catch (DbUpdateException ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    public IActionResult RecuperaCardPorId(int id)
    {
        Card? card = _context.Cards?.FirstOrDefault(card => card.Id == id);

        ReadCardDto dto = _mapper.Map<ReadCardDto>(card);
        if (card is null) { return new NotFoundObjectResult("Card não encontrado"); }
        
        return new OkObjectResult(dto);
    }

    public IActionResult AlteraCard(int id, UpdateCardDto dto)
    {
        Card? card = _context.Cards?.FirstOrDefault(card => card.Id == id);

        if (card is null) { return new NotFoundObjectResult("Card não encontrado"); }

        _mapper.Map(dto, card);
        _context.SaveChanges();

        return new OkObjectResult(card);
    }

    public IActionResult DeleteCard(int id)
    {
        Card? card = _context.Cards?.FirstOrDefault(card => card.Id == id);

        if (card is null) { return new NotFoundObjectResult("Card não encontrado"); }

        _context.Cards?.Remove(card);
        _context.SaveChanges();

        return new OkObjectResult(_context.Cards);
    }

    public IActionResult RecuperaCards(int skip,int take)
    {
        IEnumerable<Card>? cards = _context.Cards?.Skip(skip).Take(take);
        IEnumerable<ReadCardDto>? dtos = _mapper.Map<List<ReadCardDto>>(cards);

        return new OkObjectResult(dtos);
    }
}
