using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class ToDo
    {

        public long Id { get; set; }

        [Required(ErrorMessage = "Title is required"), MaxLength(100, ErrorMessage = "Maximum 100 characters")]
        public string Title { get; set; }

        [MaxLength(1000, ErrorMessage = "Maximum 1000 characters")]
        public string Description { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string MailTo { get; set; }

        [Required(ErrorMessage = "Title is required"), Range(1, 5, ErrorMessage = "range from 1 to 5")]
        public uint Priority { get; set; }

        public DateTime CreateDate { get; set; }
    }
}