using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.AccountsModule
{
  public class SecondaryAccount : Account
  {

    [NotMapped]
    public ICollection<JournalEntry> journalEntrys { get; set; } = new List<JournalEntry>();
  }
}
