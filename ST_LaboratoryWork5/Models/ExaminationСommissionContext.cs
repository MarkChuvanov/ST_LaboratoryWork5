using System.Data.Entity;

namespace ST_LaboratoryWork5.Models
{
	public class ExaminationСommissionContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<CommissionMember> CommissionMembers { get; set; }
	}
}