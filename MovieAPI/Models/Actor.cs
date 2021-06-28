using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace MovieAPI.Models
{
  public class Actor
  {
    public int ActorId { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]
    public int Age { get; set; }
    
    [Required]
    public bool OscarWinner { get; set; }

    public int MovieId { get; set; }

    // public virtual Movie Movie { get; set; }
  }
}