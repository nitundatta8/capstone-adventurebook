using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace AdventureBook.Models
{
  public class Campaign
  {
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
    public string ProductName { get; set; }
    public string ProductUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Commission { get; set; }

  }
}