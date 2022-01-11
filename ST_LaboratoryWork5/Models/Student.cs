using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ST_LaboratoryWork5.Models
{
	public class Student
	{
		public int Id { get; set; }

		[Required, DisplayName("ФИО студента")]
		public string Name { get; set; }

		[DisplayName("Оценка за экзамен"), Range(2, 5)]
		public int? Mark { get; set; }

		[Required, DisplayName("Допуск к экзамену")]
		public bool IsAdmitted { get; set; }
	}
}