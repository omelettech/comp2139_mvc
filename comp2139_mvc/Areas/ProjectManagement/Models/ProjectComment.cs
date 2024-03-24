using System.ComponentModel.DataAnnotations;
using comp2139_mvc.Areas.ProjectManagement.Models;

namespace comp2139_mvc.Areas.ProjectManagement.Models
{
    public class ProjectComment
    {
        [Key]
        public int ProjectCommentId {  get; set; }
        [Required]
        [Display(Name = "Comment")]
        [StringLength(500, ErrorMessage = "cannot exceed 500 characters")]
        public string? Content { get; set; }

        [Display(Name = "Posted Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }

        public int ProjectId { get; set; }
    }
}
