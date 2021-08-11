﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Space
    {
        public int SpaceId { get;  set; }
        public string Name { get;  set; }
        public string IsAccessible { get; set; }
        public DateTime OpenFrom { get;  set; }
        public DateTime OpenTo { get;  set; }

        public string OpenFromAbb { get; set; }
        public string OpenToAbb { get; set; }
        public decimal DailyRate { get;  set; }
        public int MaxOccupancy { get;  set; }
        public decimal TotalCost { get; set; }
        

        public Space()
        {
        }
        
    }
}
