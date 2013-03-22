using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BestFitBusinessLayer.Models
{

	public partial class company
	{

		public static Boolean Exists(String companyName, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			if (db.companies.SingleOrDefault(obj => obj.companyName == companyName) != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public int Save(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			if (db.companies.SingleOrDefault(obj => obj.companyName == this.companyName) == null)
			{
				db.companies.Add(this);
				db.SaveChanges();
				return 1;
			}
			else
			{
				return 0;
			}
		}

		public int Update(BestFitPCBContext db = null)
		{
			try
			{
				if (db == null) db = new BestFitPCBContext();
				db.Entry(this).State = EntityState.Modified;
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Delete(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			db.companies.Remove(this);
			db.SaveChanges();
			return 1;
		}

		public static company FindById(int companyId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return db.companies.SingleOrDefault(obj => obj.companyId == companyId);
		}

		public static List<company> GetList(int userId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return (from obj in db.companies
					join objUsr in db.companyUsers on obj.companyId
						equals objUsr.companyId
					where objUsr.userId == userId
					select obj).ToList();
		}

	}

	public partial class companyUser
	{
		public static Boolean Exists(int companyId, int userId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			if (db.companyUsers.SingleOrDefault(obj => obj.companyId == companyId && obj.userId == userId) != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public int Save(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			if (db.companyUsers.SingleOrDefault(obj => obj.companyId == this.companyId && obj.userId == this.userId) == null)
			{
				db.companyUsers.Add(this);
				db.SaveChanges();
				return 1;
			}
			else
			{
				return 0;
			}
		}

		public int Update(BestFitPCBContext db = null)
		{
			try
			{
				if (db == null) db = new BestFitPCBContext();
				db.Entry(this).State = EntityState.Modified;
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Delete(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.companyUsers.Remove(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public static companyUser FindById(int companyId, int userId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return db.companyUsers.SingleOrDefault(obj => obj.companyId == companyId && obj.userId == userId);
		}
	}

	public partial class companyProfile
	{

		public static Boolean Exists(String profileName, int companyId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			if (db.companyProfiles.SingleOrDefault(obj => obj.profileName == profileName && obj.companyId == companyId) != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public int Save(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			if (db.companyProfiles.SingleOrDefault(obj => obj.profileName == this.profileName && obj.companyId == this.companyId) == null)
			{
				db.companyProfiles.Add(this);
				db.SaveChanges();
				return 1;
			}
			else
			{
				return 0;
			}
		}

		public int Update(BestFitPCBContext db = null)
		{
			try
			{
				if (db == null) db = new BestFitPCBContext();
				db.Entry(this).State = EntityState.Modified;
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Delete(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.companyProfiles.Remove(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public static companyProfile FindById(int profileId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return db.companyProfiles.SingleOrDefault(obj => obj.profileId == profileId);
		}

		public static List<companyProfile> GetList(int companyId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return (from obj in db.companyProfiles
					where obj.companyId == companyId
					select obj).ToList();
		}

	}

	public partial class arraySpacing
	{
		public int Save(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.arraySpacings.Add(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Update(BestFitPCBContext db = null)
		{
			try
			{
				if (db == null) db = new BestFitPCBContext();
				db.Entry(this).State = EntityState.Modified;
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Delete(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.arraySpacings.Remove(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public static arraySpacing FindById(int arraySpacingId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return db.arraySpacings.SingleOrDefault(obj => obj.arraySpacingId == arraySpacingId);
		}

		public static List<arraySpacing> GetList(int profileId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return (from obj in db.arraySpacings
					where obj.profileId == profileId
					select obj).ToList();
		}

	}

	public partial class panelSpacing
	{
		public int Save(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.panelSpacings.Add(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Update(BestFitPCBContext db = null)
		{
			try
			{
				if (db == null) db = new BestFitPCBContext();
				db.Entry(this).State = EntityState.Modified;
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Delete(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.panelSpacings.Remove(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public static panelSpacing FindById(int panelSpacingId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return db.panelSpacings.SingleOrDefault(obj => obj.panelSpacingId == panelSpacingId);
		}

		public static List<panelSpacing> GetList(int profileId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return (from obj in db.panelSpacings
					where obj.profileId == profileId
					select obj).ToList();
		}

	}

	public partial class cupon
	{
		public int Save(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.cupons.Add(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Update(BestFitPCBContext db = null)
		{
			try
			{
				if (db == null) db = new BestFitPCBContext();
				db.Entry(this).State = EntityState.Modified;
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Delete(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.cupons.Remove(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public static cupon FindById(int cuponId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return db.cupons.SingleOrDefault(obj => obj.cuponId == cuponId);
		}

		public static List<cupon> GetList(int profileId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return (from obj in db.cupons
					where obj.profileId == profileId
					select obj).ToList();
		}

	}

	public partial class panelSize
	{
		public int Save(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.panelSizes.Add(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Update(BestFitPCBContext db = null)
		{
			try
			{
				if (db == null) db = new BestFitPCBContext();
				if (this.@default == true) panelSize.noDefault(this.panelSizeId, db);
				db.Entry(this).State = EntityState.Modified;
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Delete(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.panelSizes.Remove(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public static int noDefault(long panelSizeId, BestFitPCBContext db = null)
		{
			try
			{
				if (db == null) db = new BestFitPCBContext();
				db.panelSizes.Where(p => p.panelSizeId != panelSizeId).ToList().ForEach(ps => ps.@default = false);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public static panelSize FindById(int panelSizeId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return db.panelSizes.SingleOrDefault(obj => obj.panelSizeId == panelSizeId);
		}

		public static List<panelSize> GetList(int profileId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return (from obj in db.panelSizes
					where obj.profileId == profileId
					select obj).ToList();
		}

	}

	public partial class panelTooling
	{
		public int Save(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.panelToolings.Add(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Update(BestFitPCBContext db = null)
		{
			try
			{
				if (db == null) db = new BestFitPCBContext();
				db.Entry(this).State = EntityState.Modified;
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Delete(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.panelToolings.Remove(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public static panelTooling FindById(int panelToolingId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return db.panelToolings.SingleOrDefault(obj => obj.panelToolingId == panelToolingId);
		}

		public static List<panelTooling> GetList(int profileId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return (from obj in db.panelToolings
					where obj.profileId == profileId
					select obj).ToList();
		}

	}

	public partial class drowingColor
	{
		public int Save(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.drowingColors.Add(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Update(BestFitPCBContext db = null)
		{
			try
			{
				if (db == null) db = new BestFitPCBContext();
				db.Entry(this).State = EntityState.Modified;
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public int Delete(BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			try
			{
				db.drowingColors.Remove(this);
				db.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}

		public static drowingColor FindById(int drowingId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return db.drowingColors.SingleOrDefault(obj => obj.drowingId == drowingId);
		}

		public static List<drowingColor> GetList(int profileId, BestFitPCBContext db = null)
		{
			if (db == null) db = new BestFitPCBContext();
			return (from obj in db.drowingColors
					where obj.profileId == profileId
					select obj).ToList();
		}

	}

}
