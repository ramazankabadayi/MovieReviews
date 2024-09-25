using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviewsEL.Entities
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [ForeignKey("Film")]
        public int FilmId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; } 

        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }

        // Navigasyon property'leri
        public Film Film { get; set; }
        public User User { get; set; }
    }

}
