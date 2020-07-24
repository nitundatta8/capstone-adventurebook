using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdventureBook.Models;

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
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<AdventureImage>> Get()
    {
      return adventureDB.AdventureImages.ToList();
    }

  }
}
