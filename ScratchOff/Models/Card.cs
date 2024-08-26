using System.Reflection.Metadata.Ecma335;

namespace ScratchOff.Models;
public class Card
{
    public int Id{get;set;}
    public string? Name{get; set;}= string.Empty;
    public int StartNumber{get; set;}
    public int EndNumber{get; set;}
    public decimal TicketPrice{get; set;}

    /*
    public decimal Amount
    {
        get => _amount;
        set => _amount = (EndNumber - StartNumber)* TicketPrice;
    }

    private decimal _amount;

    */
}