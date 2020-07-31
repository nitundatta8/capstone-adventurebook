using System.Collections.Generic;


namespace AdventureBook.Models
{
  public class User
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public virtual ICollection<AdventureImage> AdventureImages { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<ClickCommision> ClickCommisions { get; set; }

    public User() { }
    public User(AdventureImage adventure, Comment comment)
    {
      this.AdventureImages = new HashSet<AdventureImage>();
      this.Comments = new HashSet<Comment>();
      this.ClickCommisions = new HashSet<ClickCommision>();
    }
  }
}