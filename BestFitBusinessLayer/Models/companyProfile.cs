
namespace BestFitBusinessLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class companyProfile
    {
        public int profileId { get; set; }
        public string profileName { get; set; }
        public int companyId { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime modifiedDate { get; set; }
    }
}
