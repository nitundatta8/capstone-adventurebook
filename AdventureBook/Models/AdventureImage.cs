using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace AdventureBook.Models
{
  public class AdventureImage
  {
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public DateTime CurrentDate { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    [NotMapped]
    public virtual IFormFile ImgFile { get; set; }


    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<TagProduct> TagProducts { get; set; }
    public AdventureImage()
    {
      this.Comments = new HashSet<Comment>();
      this.TagProducts = new HashSet<TagProduct>();
    }

  }
}
