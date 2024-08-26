
using ScratchOff.Models;

namespace ScratchOff.Services;

public interface ICardsService
{
    Task<IEnumerable<Card>> GetAllCards();
    Task<Card> GetCardById(int cardId);
    Task<Card> AddCard(Card card);
    Task<Card> UpdateCard(Card card);
    Task DeleteCard(int cardId);
}