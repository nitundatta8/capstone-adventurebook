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
  public class ClickCommisionController : ControllerBase
  {
    private AdventureContext clickComDB;

    public ClickCommisionController(AdventureContext db)
    {
      clickComDB = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ClickCommision>> Get()
    {
      return clickComDB.ClickCommisions.Include(clickCommisions => clickCommisions.User).Include(clickCommisions => clickCommisions.Campaign).ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<ClickCommision> Get(int id)
    {
      return clickComDB.ClickCommisions.FirstOrDefault(entry => entry.ClickCommisionId == id);
    }

    [HttpPost]
    public void Post([FromBody] ClickCommision clickCommision)

    {
      Campaign campaign = clickComDB.Campaigns.FirstOrDefault(entry => entry.Id == clickCommision.CampaignId);
      clickCommision.Commission = campaign.Commission;
      AdventureImage adventureImage = clickComDB.AdventureImages.FirstOrDefault(entry => entry.Id == clickCommision.AdventureImageId);
      clickCommision.UserId = adventureImage.UserId;
      clickComDB.ClickCommisions.Add(clickCommision);
      clickComDB.SaveChanges();
    }


  }
}