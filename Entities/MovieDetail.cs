using System;
using System.Collections.Generic;

namespace Deltax.Entities
{
    public partial class MovieDetail
    {
        public int MovieDetailsId { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
