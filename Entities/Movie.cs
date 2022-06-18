using System;
using System.Collections.Generic;

namespace Deltax.Entities
{
    public partial class Movie
    {
        public Movie()
        {
            MovieDetails = new HashSet<MovieDetail>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public string? Plot { get; set; }
        public string Poster { get; set; } = null!;
        public DateTime? ReleaseDate { get; set; }
        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; } = null!;
        public virtual ICollection<MovieDetail> MovieDetails { get; set; }
    }
}
