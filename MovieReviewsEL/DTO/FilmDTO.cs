using MovieReviewsEL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviewsEL.DTO
{
    public class FilmDTO
    {
        public int FilmId { get; set; }

        [Required(ErrorMessage = "Film başlığı zorunludur.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Yönetmen adı zorunludur.")]
        public string Director { get; set; }

        [Range(1900, 2100, ErrorMessage = "Yıl 1900 ile 2100 arasında olmalıdır.")]
        public int Year { get; set; }

        public string? Description { get; set; }
        public string? CoverImagePath { get; set; }

        public ICollection<ReviewDTO>? Reviews { get; set; }
    }
}
