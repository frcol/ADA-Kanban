using AutoMapper;
using QuadroKanban.Data.DTO;
using QuadroKanban.Model;

namespace QuadroKanban.Profiles;

public class CardProfile: Profile
{
    public CardProfile()
    {
        CreateMap<CreateCardDto, Card>();
        CreateMap<UpdateCardDto, Card>();
        CreateMap<Card, ReadCardDto>();
    }
}
