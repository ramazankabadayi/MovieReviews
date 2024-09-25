using AutoMapper;
using MovieReviewsDL;
using MovieReviewsEL.DTO;
using MovieReviewsEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviewsBL
{
    public class FilmManager : BaseManager<Film, FilmDTO, int>
    {
        public FilmManager(MyContext context, IMapper mapper) : base(context, mapper)
        {
            
        }
        public bool AddNewData(FilmDTO data)
        {
            try
            {
                var entity = _mapper.Map<FilmDTO,Film>(data);
                _myContext.Films.Add(entity);   
                int affectedRows = _myContext.SaveChanges();
                return affectedRows > 0;         
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return false;
            }
        }

        public bool UpdateData(FilmDTO data)
        {
            try
            {
                var entity = _myContext.Films.Find(data.FilmId);
                if (entity == null) return false;
                _mapper.Map(data, entity);
                _myContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteData(int id)
        {
            try
            {
                var entity = _myContext.Films.Find(id);
                if (entity == null) return false;
                _myContext.Films.Remove(entity);
                _myContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


    }
}

