using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Xassee.Training.CRM.Api.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
