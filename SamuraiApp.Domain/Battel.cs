﻿using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace SamuraiApp.Domain
{
   public class Battel
    {
        public Battel()
        {
            SamuraiBattels = new List<SamuraiBattel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SamuraiBattel> SamuraiBattels { get; set; }
    }
}
