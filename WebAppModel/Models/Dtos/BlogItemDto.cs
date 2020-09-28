using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppModel.Models.Dtos
{
    public class BlogItemDto
    {
        [Display(Name = "Title Post")]
        [Required]
        [StringLength(100, MinimumLength = 5,
        ErrorMessage = "Title must be between 5 and characters long")]
        public string Title { get; set; }
        
        [Required]
        [MinLength(100,
        ErrorMessage = "Blog posts must be at last 100 charcters long")]
        public string Body { get; set; }
    }
}
