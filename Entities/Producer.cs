using System;
using System.Collections.Generic;

namespace Deltax.Entities
{
    public partial class Producer
    {
        public Producer()
        {
            Movies = new HashSet<Movie>();
        }

        public int ProducerId { get; set; }
        public string ProducerName { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string Comapny { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
