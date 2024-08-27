
using System.Reflection;
using IndexedDB.Blazor;
using Microsoft.JSInterop;
using ScratchOff.Models;



namespace ScratchOff.Data;

public class ScratcherDb: IndexedDb
{
    public ScratcherDb (IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version)
    {

    }

    //These are like DbSet related to tables
    public IndexedSet<Card>? Cards{get; set;}

   
   
}
