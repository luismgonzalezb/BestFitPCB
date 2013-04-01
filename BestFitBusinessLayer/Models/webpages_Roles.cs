
namespace BestFitBusinessLayer.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class webpages_Roles
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RoleId { get; set; }
		public string RoleName { get; set; }
	}
}
