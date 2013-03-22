
namespace BestFitBusinessLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserProfile
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
