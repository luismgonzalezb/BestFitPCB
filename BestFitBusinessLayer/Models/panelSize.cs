
namespace BestFitBusinessLayer.Models
{
	using System.ComponentModel.DataAnnotations;

	public partial class panelSize
	{
		[Key]
		public long panelSizeId { get; set; }
		public int profileId { get; set; }
		public decimal x { get; set; }
		public decimal y { get; set; }
		public bool @default { get; set; }
	}
}
