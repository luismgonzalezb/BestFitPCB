
namespace BestFitBusinessLayer.Models
{
	using System.ComponentModel.DataAnnotations;

	public partial class panelTooling
	{
		[Key]
		public long panelToolingId { get; set; }
		public int profileId { get; set; }
		public string x { get; set; }
		public string y { get; set; }
		public string r { get; set; }
	}
}
