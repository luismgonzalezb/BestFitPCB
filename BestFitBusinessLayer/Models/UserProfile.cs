
namespace BestFitBusinessLayer.Models
{
	using System.ComponentModel.DataAnnotations;

	public partial class UserProfile
	{
		[Key]
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
	}
}
