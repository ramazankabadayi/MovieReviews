using AutoMapper;
using MovieReviewsEL.DTO;
using MovieReviewsEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviewsBL
{
    public class MapperConfig:Profile
    {     
        public MapperConfig()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Film, FilmDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
        }
    }
}
