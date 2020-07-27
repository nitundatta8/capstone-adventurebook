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
  public class AdventureImageController : ControllerBase
  {

    private AdventureContext adventureDB;

    public AdventureImageController(AdventureContext db)
    {
      adventureDB = db;
    }
    //GET api/AdventureImages
    [HttpGet]
    public ActionResult<IEnumerable<AdventureImage>> Get()
    {
      return adventureDB.AdventureImages.ToList();
    }

    // GET api/AdventureImages/2
    [HttpGet("{id}")]

    public ActionResult<AdventureImage> GetAction(int id)
    {
      return adventureDB.AdventureImages.Include(adventure => adventure.Comments)
      .FirstOrDefault(entry => entry.Id == id);
    }

    // GET api/AdventureImages/Seattle

    [HttpGet("location/{location}")]
    public ActionResult<IEnumerable<AdventureImage>> Get(string location)
    {
      var query = adventureDB.AdventureImages.AsQueryable();
      if (query != null)
      {
        query = query.Where(entry => entry.Location == location);
      }

      return query.ToList();

    }

    //POST api/AdventureImages
    [HttpPost]
    public void Post([FromBody] AdventureImage adventureImage)
    {
      adventureDB.AdventureImages.Add(adventureImage);
      adventureDB.SaveChanges();
    }

    //PUT 
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] AdventureImage adventureImage)
    {
      adventureImage.Id = id;
      adventureDB.Entry(adventureImage).State = EntityState.Modified;
      adventureDB.SaveChanges();
    }

    //DELETE
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var adventureToDelete = adventureDB.AdventureImages.FirstOrDefault(entry => entry.Id == id);
      adventureDB.AdventureImages.Remove(adventureToDelete);
      adventureDB.SaveChanges();
    }
  }
}
