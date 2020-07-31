using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdventureBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureBook.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TagProductController : ControllerBase
  {
    private AdventureContext tagDB;

    public TagProductController(AdventureContext db)
    {
      tagDB = db;
    }
    [HttpGet]
    public ActionResult<IEnumerable<TagProduct>> Get()
    {
      return tagDB.TagProducts.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<TagProduct> Get(int id)
    {
      return tagDB.TagProducts.FirstOrDefault(entry => entry.Id == id);
    }

    [HttpGet("getTagProductById/{adventureImgId}")]
    // [Route("getparam")]
    public ActionResult<IEnumerable<TagProduct>> GetTagProductById(int adventureImgId)
    {
      var query = tagDB.TagProducts.AsQueryable();

      if (adventureImgId > 0) 
      {
        query = query.Where(entry => entry.AdventureImage.Id == adventureImgId).Include(entry => entry.Campaign);
      }

      return query.ToList();
    }

    [HttpPost]
    public void Post([FromBody] TagProduct tagProduct)
    {
      tagDB.TagProducts.Add(tagProduct);
      tagDB.SaveChanges();
    }


  }
}