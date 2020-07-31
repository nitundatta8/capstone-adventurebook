using System;

namespace AdventureBook.Models
{
  public class ClickCommision
  {
    public int ClickCommisionId { get; set; }
    public int AdventureImageId { get; set; }
    public virtual AdventureImage AdventureImage { get; set; }

    public int CampaignId { get; set; }
    public virtual Campaign Campaign { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public double Commission { get; set; }
    public DateTime ClickDate { get; set; }


  }
}
