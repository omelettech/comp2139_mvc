using System.ComponentModel.DataAnnotations;
namespace comp2139_mvc.Models
{
    public class Project
    {
        [Required] //constraints
        public int ProjectId { get; set; }
        public required string ProjectName { get; set; } //default value = "NewProj"
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueTime { get; set; }

        public string? Status {  get; set; } //default value = "not started" make it non-nullable later

        public Project()
        {

        }
    }
}
