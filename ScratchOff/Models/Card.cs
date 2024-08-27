using System.ComponentModel.DataAnnotations;
using IndexedDB.Blazor.Attributes;

namespace ScratchOff.Models;
public class Card
{
    [Key, AutoIncrement]
    public int Id{get;set;}
    [Required]
    public string? Name{get; set;}= string.Empty;
    [Required]
    public int StartNumber{get; set;}
    [Required]
    public int EndNumber{get; set;}
    [Required]
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