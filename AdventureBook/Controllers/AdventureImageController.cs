using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdventureBook.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

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

    [HttpGet("adventureImages/{imageName}")]
    public async Task<IActionResult> Download(string imageName)
    {

      var targetDir = @"C:\dev-project\epicodus_code\CapstoneEpicodus\AdventureBook.Solution\AdventureBook\uploadFiles";
      var path = Path.Combine(targetDir,
            imageName);

      var memory = new MemoryStream();
      using (var stream = new FileStream(path, FileMode.Open))
      {
        await stream.CopyToAsync(memory);
      }
      memory.Position = 0;
      var ext = Path.GetExtension(path).ToLowerInvariant();
      return File(memory, GetMimeTypes()[ext], Path.GetFileName(path));
    }

    private Dictionary<string, string> GetMimeTypes()
    {
      return new Dictionary<string, string>
        {
            {".txt", "text/plain"},
            {".pdf", "application/pdf"},
            {".doc", "application/vnd.ms-word"},
            {".docx", "application/vnd.ms-word"},
            {".png", "image/png"},
            {".jpg", "image/jpeg"}
        };
    }
    //POST api/AdventureImages
    [HttpPost]
    //[FromBody]--- form
    //[FromQuery]--- place?city=Seattle&st=wa
    //[FromForm]-- multy-part
    public ActionResult<AdventureImage> Post([FromForm] AdventureImage adventureImage)
    {

      var targetDir = @"C:\dev-project\epicodus_code\CapstoneEpicodus\AdventureBook.Solution\AdventureBook\uploadFiles";

      if (adventureImage.ImgFile.Length > 0)
      {


        var fileName = Path.GetRandomFileName().Split(".")[0] + Path.GetExtension(adventureImage.ImgFile.FileName);
        var filePath = Path.Combine(targetDir,
           fileName);

        using (var stream = System.IO.File.Create(filePath))
        {
          adventureImage.ImgFile.CopyTo(stream);
        }
        Console.WriteLine("filepath: " + filePath + " length: " + adventureImage.ImgFile.Length);
        adventureImage.ImageUrl = fileName;
      }
      else
      {
        Console.WriteLine("file content zero");
      }

      adventureDB.AdventureImages.Add(adventureImage);
      adventureDB.SaveChanges();
      return adventureImage;
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
