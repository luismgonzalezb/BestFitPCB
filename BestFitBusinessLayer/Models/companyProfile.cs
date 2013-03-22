
namespace BestFitBusinessLayer.Models
{
	using System.ComponentModel.DataAnnotations;

	public partial class companyProfile
	{
		[Key]
		public int profileId { get; set; }
		public string profileName { get; set; }
		public int companyId { get; set; }
		public System.DateTime createDate { get; set; }
		public System.DateTime modifiedDate { get; set; }
	}
}
