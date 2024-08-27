using ScratchOff.Models;
using IndexedDB.Blazor;
using ScratchOff.Data;

namespace ScratchOff.Services;

public class CardsService : ICardsService
{
    private readonly IIndexedDbFactory dbFactory;
    public ICollection<Card> cardList;
    public CardsService()

    {
        using var db = dbFactory!.Create<ScratcherDb>();
        foreach(var x in CardList())
        {
            db.Result.Cards!.Add(x);
        }
        cardList = db.Result.Cards!.ToList();
    }
    

     public async Task<IEnumerable<Card>> GetAllCards()
    {
        using var db = await dbFactory.Create<ScratcherDb>();
        cardList = db.Cards!.ToList();
        return cardList;
    }

    public async Task<Card> GetCardById(int cardId)
    {
        
        Card result = cardList.FirstOrDefault(item => item.Id == cardId)?? throw new NullReferenceException("cards null");
        return await Task.FromResult(result);
    }
    public async Task<Card> AddCard(Card card)
    {
        
        string name = card.Name ?? "none";
        int startingNumber = card.StartNumber;
        int endNumber = card.EndNumber;
        decimal price = card.TicketPrice;
        
        Card newCard = new()
        {
             Name = name, StartNumber = startingNumber, EndNumber = endNumber, TicketPrice = price
        };
        using var db = dbFactory.Create<ScratcherDb>();
        db.Result.Cards!.Add(newCard);
        cardList = db.Result.Cards.ToList();
        return await Task.FromResult(newCard);
    }

    public async Task DeleteCard(int cardId)
    {
        Card result;
        using var db = dbFactory.Create<ScratcherDb>();
        if (db.Result.Cards is not null)
        {
            result =  db.Result.Cards.FirstOrDefault(item => item.Id == cardId);
        
            if(result != null)
            {
                db.Result.Cards!.ToList().Remove(result);
            }
            
            
        }
        cardList = db.Result.Cards!.ToList();
    
        await Task.CompletedTask;
        
    }

   

    public async Task<Card> UpdateCard(Card card)
    {
        using var db = dbFactory.Create<ScratcherDb>();
        Card existingCard = db.Result.Cards.FirstOrDefault(x => x.Id == card.Id);
        if(existingCard is not null)
        {
            existingCard.Name = card.Name ?? "none";
            existingCard.StartNumber = card.StartNumber;
            existingCard.EndNumber = card.EndNumber;
            existingCard.TicketPrice = card.TicketPrice;
            cardList = db.Result.Cards.ToList();
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