using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdventureBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AdventureBook.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class CommentsController : ControllerBase
  {

    private AdventureContext commentDB;

    public CommentsController(AdventureContext db)
    {
      commentDB = db;
    }
    // http://localhost:5000/api/comments
    [HttpGet]
    public ActionResult<IEnumerable<Comment>> Get()
    {
      List<Comment> model = commentDB.Comments.Include(entry => entry.AdventureImage).Include(e => e.User).ToList();
      return model;
    }

    // Get a single review [http://localhost:5000/api/reviews/1/getaction]
    [HttpGet("getCommentByID/{id}")]
    //[Route("getReviewById")]
    public ActionResult<Comment> GetCommentByID(int id)
    {
      return commentDB.Comments.Include(comment => comment.AdventureImage).FirstOrDefault(entry => entry.Id == id);
    }

    [HttpGet("getcomments/{imgId}")]
    //[Route("getcomments")]
    public ActionResult<IEnumerable<Comment>> GetComment(int imgId)
    {
      //List<Review> model = _db.Reviews.Include(e => e.User).ToList();

      var query = commentDB.Comments.AsQueryable();

      if (imgId > 0)
      {
        query = query.Where(entry => entry.AdventureImage.Id == imgId).Include(e => e.User);
      }
      return query.ToList();
    }

    [HttpPost]
    public void Post([FromBody] Comment comment)
    {
      var claimsIdentity = this.User.Identity as ClaimsIdentity;
      var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

      var user = commentDB.Users.FirstOrDefault(entry => entry.Id.ToString() == userId);

      comment.User = user;
      commentDB.Comments.Add(comment);
      commentDB.SaveChanges();
    }

    // PUT api/campaign/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Comment comment)
    {
      comment.Id = id;
      commentDB.Entry(comment).State = EntityState.Modified;
      commentDB.SaveChanges();

    }

    // DELETE api/campaign/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var campaignDelete = commentDB.Comments.FirstOrDefault(entry => entry.Id == id);
      commentDB.Remove(campaignDelete);
      commentDB.SaveChanges();
    }
  }
}