using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ST_LaboratoryWork5.Models
{
	public class CommissionMember
	{
		public int Id { get; set; }

		[Required, DisplayName("ФИО преподавателя")]
		public string Name { get; set; }

		[Required, DisplayName("Должность преподавателя")]
		public string Duty { get; set; }
	}
}