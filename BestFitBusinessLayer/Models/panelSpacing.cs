
namespace BestFitBusinessLayer.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public partial class panelSpacing
	{
		[Key]
		public long panelSpacingId { get; set; }
		public int profileId { get; set; }
		public Nullable<decimal> min { get; set; }
		public Nullable<decimal> max { get; set; }
		public Nullable<decimal> std { get; set; }
		public string panelSpacingName { get; set; }
	}
}
