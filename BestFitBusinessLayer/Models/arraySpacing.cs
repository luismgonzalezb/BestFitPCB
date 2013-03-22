
namespace BestFitBusinessLayer.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public partial class arraySpacing
	{
		[Key]
		public long arraySpacingId { get; set; }
		public int profileId { get; set; }
		public Nullable<decimal> min { get; set; }
		public Nullable<decimal> max { get; set; }
		public Nullable<decimal> std { get; set; }
		public string arraySpacingName { get; set; }
	}
}
