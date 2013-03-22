
namespace BestFitBusinessLayer.Models
{
	using System.ComponentModel.DataAnnotations;

	public partial class webpages_OAuthMembership
	{
		[Key]
		public int UserId { get; set; }
		public string Provider { get; set; }
		public string ProviderUserId { get; set; }

	}
}
