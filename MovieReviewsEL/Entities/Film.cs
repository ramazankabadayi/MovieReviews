using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviewsEL.Entities
{
    public class Film 
    {
        [Key]
        public int FilmId { get; set; }

        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; } 
        public string? CoverImagePath { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }


}
