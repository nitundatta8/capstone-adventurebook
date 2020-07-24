using System;

namespace AdventureBook.Models
{
  public class AdventureImage
  {
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime CurrentDate { get; }

  }
}
