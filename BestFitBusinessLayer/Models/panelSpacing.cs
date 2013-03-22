
namespace BestFitBusinessLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class panelSpacing
    {
        public long panelSpacingId { get; set; }
        public int profileId { get; set; }
        public Nullable<decimal> min { get; set; }
        public Nullable<decimal> max { get; set; }
        public Nullable<decimal> std { get; set; }
        public string panelSpacingName { get; set; }
    }
}
