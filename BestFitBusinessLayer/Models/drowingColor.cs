
namespace BestFitBusinessLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class drowingColor
    {
        public long drowingId { get; set; }
        public int profileId { get; set; }
        public string background { get; set; }
        public string profile { get; set; }
        public string panel { get; set; }
        public string margin { get; set; }
        public string pcb { get; set; }
        public string tooling { get; set; }
    }
}
