using System.ComponentModel.DataAnnotations;

namespace comp2139_mvc.Areas.ProjectManagement.Models
{
	public class ProjectTask
	{
		[Key]
		public int TaskId { get; set; }
		[Required] public string? TaskName { get; set; }

		[Required] public string? TaskDescription { get; set; }

		//Foreign key
		public int projectId { get; set; }
		public Project? Project { get; set; }

	}
}
