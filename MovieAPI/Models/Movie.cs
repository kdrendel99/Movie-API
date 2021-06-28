using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MovieAPI.Models
{
  public class Movie
  {
    public Movie()
    {
      this.Actors = new HashSet<Actor>();
    }
    
    public int MovieId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Genre { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    public double Rating { get; set; }

    //foreign key (this isn't needed, no lazy loading reqd)
    [Required]
    public virtual ICollection<Actor> Actors { get; set; }


  }
}