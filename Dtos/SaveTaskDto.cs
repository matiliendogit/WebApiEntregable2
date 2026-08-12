using System.ComponentModel.DataAnnotations;

namespace WebApiEntregable2.Dtos
{
    public class SaveTaskDto
    {
        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100, ErrorMessage = "The Title field must be a maximum of 100 characters.")]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(250, ErrorMessage = "The Description field must be a maximum of 250 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "The IsCompleted field is required.")]
        public bool IsCompleted { get; set; } = false;
    }
}
