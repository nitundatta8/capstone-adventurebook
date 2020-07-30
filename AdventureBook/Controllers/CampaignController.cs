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
  public class CampaignController : ControllerBase
  {

    private AdventureContext campaignDB;

    public CampaignController(AdventureContext db)
    {
      campaignDB = db;
    }
    // GET api/campaign
    [HttpGet]
    public ActionResult<IEnumerable<Campaign>> Get()
    {
      return campaignDB.Campaigns.ToList();
    }

    // GET api/campaign/5
    [HttpGet("{id}")]
    public ActionResult<Campaign> Get(int id)
    {
      return campaignDB.Campaigns.FirstOrDefault(entry => entry.Id == id);
    }

    [HttpGet("{brand}/{category}")]
    // [Route("getparam")]
    public ActionResult<IEnumerable<Campaign>> GetParam(string brand, string category)
    {
      var query = campaignDB.Campaigns.AsQueryable();

      if (brand != null && category != null)
      {
        query = query.Where(entry => entry.Brand == brand && entry.Category == category);
      }

      return query.ToList();
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] Campaign campaign)
    {
      campaignDB.Campaigns.Add(campaign);
      campaignDB.SaveChanges();
    }

    // PUT api/campaign/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Campaign campaign)
    {
      campaign.Id = id;
      campaignDB.Entry(campaign).State = EntityState.Modified;
      campaignDB.SaveChanges();

    }

    // DELETE api/campaign/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var campaignDelete = campaignDB.Campaigns.FirstOrDefault(entry => entry.Id == id);
      campaignDB.Remove(campaignDelete);
      campaignDB.SaveChanges();
    }
  }
}

