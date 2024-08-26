using ScratchOff.Models;

namespace ScratchOff.Services;

public class CardsService : ICardsService
{
    public CardsService()
    {
        foreach(var x in CardList())
        {
            cards.Add(x);
        }
    }
    public ICollection<Card> cards = new List<Card>();

     public async Task<IEnumerable<Card>> GetAllCards()
    {
        
        return await Task.FromResult(cards);
    }

    public async Task<Card> GetCardById(int cardId)
    {
        
        Card result = cards.FirstOrDefault(item => item.Id == cardId)?? throw new NullReferenceException("cards null");
        return await Task.FromResult(result);
    }
    public async Task<Card> AddCard(Card card)
    {
        int cardId = cards.Count + 1;
        string name = card.Name ?? "none";
        int startingNumber = card.StartNumber;
        int endNumber = card.EndNumber;
        decimal price = card.TicketPrice;
        
        Card newCard = new()
        {
            Id= cardId, Name = name, StartNumber = startingNumber, EndNumber = endNumber, TicketPrice = price
        };
        cards.Add(newCard);
        return await Task.FromResult(newCard);
    }

    public async Task DeleteCard(int cardId)
    {
        Card result;

        if (cards is not null)
        {
            result =  cards.FirstOrDefault(item => item.Id == cardId);
        
            if(result != null)
            {
                cards.Remove(result);
            }
            
        }
    
        await Task.CompletedTask;
        
    }

   

    public async Task<Card> UpdateCard(Card card)
    {
        Card existingCard = cards.FirstOrDefault(x => x.Id == card.Id);
        if(existingCard is not null)
        {
            existingCard.Id= card.Id;
            existingCard.Name = card.Name ?? "none";
            existingCard.StartNumber = card.StartNumber;
            existingCard.EndNumber = card.EndNumber;
            existingCard.TicketPrice = card.TicketPrice;
            return await Task.FromResult(existingCard);
        }
       
        return null;
    }

     private static  List<Card> CardList()
    {
        List<Card> cards = new()
            {
                new Card{Id = 1, Name = "a", StartNumber = 1, EndNumber = 35, TicketPrice = 5},
                new Card{Id = 2, Name = "b", StartNumber = 0, EndNumber = 0, TicketPrice = 0},
                new Card{Id = 3, Name = "c", StartNumber = 3, EndNumber = 34, TicketPrice = 10},
                new Card{Id = 4, Name = "d", StartNumber = 0, EndNumber = 0, TicketPrice = 0},
                new Card{Id = 5, Name = "e", StartNumber = 0, EndNumber = 0, TicketPrice = 0}     

            };
            return cards;
    }
}