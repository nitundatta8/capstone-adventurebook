using System;
using System.Collections.Generic;

namespace AdventureBook.Models
{
  public class AdventureImage
  {
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime CurrentDate { get; }

    public virtual ICollection<Comment> Comments { get; set; }
    public AdventureImage()
    {
      this.Comments = new HashSet<Comment>();
    }

  }
}
