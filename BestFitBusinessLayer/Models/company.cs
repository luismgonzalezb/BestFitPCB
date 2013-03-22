
namespace BestFitBusinessLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class company
    {
        public int companyId { get; set; }
        public string companyName { get; set; }
        public string companyPhone { get; set; }
        public string companyEmail { get; set; }
        public string companyAddress { get; set; }
        public string companyAddress2 { get; set; }
        public string companyCity { get; set; }
        public string companyState { get; set; }
        public string companyCountry { get; set; }
    }
}
