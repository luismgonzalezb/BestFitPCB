
namespace BestFitBusinessLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cupon
    {
        public long cuponId { get; set; }
        public int profileId { get; set; }
        public Nullable<decimal> height { get; set; }
        public string color { get; set; }
        public Nullable<decimal> spacing { get; set; }
        public Nullable<decimal> width { get; set; }
        public string cuponName { get; set; }
    }
}
