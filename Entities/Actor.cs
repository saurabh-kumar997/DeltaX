using System;
using System.Collections.Generic;

namespace Deltax.Entities
{
    public partial class Actor
    {
        public Actor()
        {
            MovieDetails = new HashSet<MovieDetail>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }

        public virtual ICollection<MovieDetail> MovieDetails { get; set; }
    }
}
