using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviewsEL.Entities
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        public string? Email { get; set; }
        [Required]
        public ICollection<Review> Reviews { get; set; }
    }
}
