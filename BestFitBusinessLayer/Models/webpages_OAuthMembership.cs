
namespace BestFitBusinessLayer.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class webpages_OAuthMembership
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int UserId { get; set; }
		public string Provider { get; set; }
		public string ProviderUserId { get; set; }

	}
}
