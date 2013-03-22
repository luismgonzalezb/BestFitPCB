
namespace BestFitBusinessLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class companyUser
    {
        public int userId { get; set; }
        public int companyId { get; set; }
        public bool deleted { get; set; }
        public bool admin { get; set; }
    }
}
