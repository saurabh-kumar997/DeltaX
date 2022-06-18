using System;
using System.Collections.Generic;

namespace Deltax.Entities
{
    public partial class Master
    {
        public int MasterId { get; set; }
        public string MasterName { get; set; } = null!;
        public string MasterType { get; set; } = null!;
    }
}
