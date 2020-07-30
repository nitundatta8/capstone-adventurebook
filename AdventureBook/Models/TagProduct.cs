namespace AdventureBook.Models
{
  public class TagProduct
  {
    public int Id { get; set; }
    public int XPos { get; set; }
    public int YPos { get; set; }

    public int CampaignId { get; set; }

    public virtual Campaign Campaign { get; set; }

    public int AdventureImageId { get; set; }
    public virtual AdventureImage AdventureImage { get; set; }




  }
}
