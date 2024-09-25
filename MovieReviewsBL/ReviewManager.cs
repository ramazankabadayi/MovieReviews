using MovieReviewsEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviewsDL;
using Microsoft.EntityFrameworkCore;
using MovieReviewsEL.DTO;
using AutoMapper;

namespace MovieReviewsBL
{
    public class ReviewManager
    {
        private readonly MyContext _myContext;
        private readonly IMapper _mapper;

        public ReviewManager(MyContext context, IMapper mapper)
        {
            _myContext = context;
            _mapper = mapper;
        }

        public bool AddNewData(ReviewDTO reviewDto)
        {
            try
            {
                var reviewEntity = _mapper.Map<ReviewDTO, Review>(reviewDto);

                reviewEntity.Film = _myContext.Films.Find(reviewDto.FilmId);
                reviewEntity.User = _myContext.Users.Find(reviewDto.UserId);

                _myContext.Reviews.Add(reviewEntity);
                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return false;
            }
        }

    }
}
