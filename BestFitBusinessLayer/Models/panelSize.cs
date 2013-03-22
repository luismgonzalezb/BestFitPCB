
namespace BestFitBusinessLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class panelSize
    {
        public long panelSizeId { get; set; }
        public int profileId { get; set; }
        public decimal x { get; set; }
        public decimal y { get; set; }
        public bool @default { get; set; }
    }
}
