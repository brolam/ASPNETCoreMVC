using System;

namespace WebAppModel.Models
{
    public class BlogItem
    {
        public string Title { get; set; }
        public DateTime Posted { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
    }
    
}