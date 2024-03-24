using System.ComponentModel.DataAnnotations;
namespace comp2139_mvc.Areas.ProjectManagement.Models
{
    public class Project
    {
        [Key] //constraints
        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [StringLength(50, ErrorMessage = "Too long of a name bro")]
        public string ProjectName { get; set; } //default value = "NewProject"

        [Display(Name = "Description")]
        [StringLength(5000, ErrorMessage = "You dont 5000 characters bro")]
        public string? Description { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-DD}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Due time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-DD}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DueTime { get; set; }

    
        [Display(Name = "Project Status")]
        [StringLength(50, ErrorMessage = "Too long of a name bro")]
        public string? Status { get; set; } //default value = "not started" make it non-nullable later

		public List<ProjectTask>? Tasks { get; set; }

		
    }
}
