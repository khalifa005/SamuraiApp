using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
    public class SamuraiBattel
    {
        public int SamuraiId { get; set; }
        public int BattelId { get; set; }

        public Samurai Samurai { get; set; }
        public Battel Battel { get; set; }
    }
}
