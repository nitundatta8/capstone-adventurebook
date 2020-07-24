using System;

namespace AdventureBook.Models
{
  public class Comment
  {
    public int Id { get; set; }
    public string Comments { get; set; }
    public int ImageId { get; set; }
    public virtual AdventureImage AdventureImage { get; set; }


    public int UserId { get; set; }
    public User User { get; set; }


  }
}
