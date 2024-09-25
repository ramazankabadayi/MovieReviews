using MovieReviewsEL.DTO;

namespace WebUI.Models
{
    public class FilmDetailsViewModel
    {
        public FilmDTO Film { get; set; }
        public List<ReviewDTO> Reviews { get; set; }
    }

}
