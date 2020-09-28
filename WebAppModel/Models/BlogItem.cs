using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppModel.Models
{
    public class BlogItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Posted { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Body { get; set; }
    }

}