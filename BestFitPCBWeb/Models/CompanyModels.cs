using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using BestFitBusinessLayer;

namespace BestFitPCBWeb.Models
{

    public class CreateCompanyModel
    {
        [Required]
        [Display(Name = "Company Name")]
        public string companyName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string companyPhone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string companyEmail { get; set; }
    }

    [Serializable]
    public class searchObject
    {
        public string label { get; set; }
        public int value { get; set; }
    }

}
