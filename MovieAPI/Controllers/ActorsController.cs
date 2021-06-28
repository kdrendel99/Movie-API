using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using MovieAPI.Models;
using System;
using System.Linq;

namespace MovieAPI.Controllers
{
  [Route("api/movies/{movieId}/[controller]")]
  [ApiController]
  public class ActorsController : ControllerBase
  {
    private readonly MovieAPIContext _db;
    public ActorsController(MovieAPIContext db)
    {
      _db = db;
    }

  //GET api/movies/1/actors

  [HttpGet]
  public async Task<ActionResult<IEnumerable<Actor>>> Get(int movieId)
  {

    var query = _db.Actors.AsQueryable();

    if (movieId != 0)
    {
      query = query.Where(entry => entry.MovieId == movieId);
    }

    return await query.ToListAsync();
    // List<Actor> movieActorList = _db.Actors.Where(e => e.MovieId == movieId);
    // return await movieActorList.ToListAsync();
  }
  // [HttpGet]
  // public async Task<ActionResult<IEnumerable<Actor>>> Get(string name, int age, bool oscarWinner, int movieId)
  // {
  //   var query = _db.Actors.AsQueryable();

  //     if (name != null)
  //     {
  //       query = query.Where(entry => entry.Name == name);
  //     }

  //     if (age != 0)
  //     {
  //       query = query.Where(entry => entry.Age == age);
  //     }

  //     if (oscarWinner != true || false)
  //     {
  //       query = query.Where(entry => entry.OscarWinner == oscarWinner);
  //     }

  //     if (movieId != 0)
  //     {
  //       query = query.Where(entry => entry.MovieId == movieId);
  //     }
  //     return await query.ToListAsync();
  // }

    //POST api/movies/1/actors
    [HttpPost]
    public async Task<ActionResult<Actor>> Post(int movieId, Actor actor)
    {
      actor.MovieId = movieId;
      _db.Actors.Add(actor);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = actor.ActorId, actor});
      // return CreatedAtAction(nameof(GetActor), new { id = actor.ActorId }, actor);
    }

    //Get: api/movies/1/actors/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Actor>> GetActor(int id)
    {
      var actor = await _db.Actors.FindAsync(id);

      if (actor == null)
      {
        return NotFound();
      }

      return actor;
    }
    //PUT: api/movies/1/Actors/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Actor actor)
    {
      if (id != actor.ActorId)
      {
        return BadRequest();
      }
      _db.Entry(actor).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ActorExists(id))
        {
          return NotFound();
        }
        else 
        {
          throw;
        }
      }
      return NoContent();
    }
    //DELETE: api/movies/1/Actors/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActor(int id)
    {
      var actor = await _db.Actors.FindAsync(id);
      if (actor == null)
      {
        return NotFound();
      }
      _db.Actors.Remove(actor);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool ActorExists(int id)
    {
      return _db.Actors.Any(e => e.ActorId == id);
    }
  }
}