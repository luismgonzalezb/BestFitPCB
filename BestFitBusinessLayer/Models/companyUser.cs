
namespace BestFitBusinessLayer.Models
{
	using System.ComponentModel.DataAnnotations;

	public partial class companyUser
	{
		[Key]
		public int userId { get; set; }
		public int companyId { get; set; }
		public bool deleted { get; set; }
		public bool admin { get; set; }
	}
}
