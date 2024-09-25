using MovieReviewsEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviewsDL;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq.Expressions;

namespace MovieReviewsBL
{
    public class BaseManager<T, TDTO, Tid> where T : class, new()
    {
        public readonly MyContext _myContext;
        public readonly IMapper _mapper;
        public readonly string[] _joinTableNames;

        public BaseManager(MyContext context, IMapper mapper, string[] joinTableNames = null)
        {
            _myContext = context ?? throw new ArgumentNullException(nameof(context));  
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));   
            _joinTableNames = joinTableNames;
        }


  

        public List<TDTO> GetAllData()
        {
            try
            {
                var data = _myContext.Set<T>().ToList();
                return _mapper.Map<List<T>, List<TDTO>>(data);
             
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TDTO> GetSomeData(Expression<Func<T, bool>> whereFilter, params Expression<Func<T, object>>[] includes)
        {
            try
            {
             
                IQueryable<T> query = _myContext.Set<T>().Where(whereFilter);

                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                var entities = query.ToList();
                return _mapper.Map<List<T>, List<TDTO>>(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TDTO> GetAllDataWithJoin()
        {
            try
            {
                if (_joinTableNames == null)
                {
                    return _mapper.Map<List<T>, List<TDTO>>(_myContext.Set<T>().ToList());
                }


                var query = _myContext.Set<T>().AsQueryable(); 
                foreach (string tableName in _joinTableNames)
                {
                    query = query.Include(tableName);
                }
                return _mapper.Map<List<T>, List<TDTO>>(query.ToList());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TDTO> GetAllDataWithJoin(Expression<Func<T, bool>> whereFilter)
        {
            try
            {
                if (_joinTableNames == null)
                {
                    return _mapper.Map<List<T>, List<TDTO>>(_myContext.Set<T>().Where(whereFilter).ToList());
                }


                var query = _myContext.Set<T>().Where(whereFilter).AsQueryable(); 
                foreach (string tableName in _joinTableNames)
                {
                    query = query.Include(tableName);
                }
                return _mapper.Map<List<T>, List<TDTO>>(query.ToList());
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool AddNewData(TDTO data)
        {
            try
            {              
                var entity = _mapper.Map<TDTO, T>(data);
                _myContext.Set<T>().Add(entity);

                return _myContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }
        public bool UpdateData(TDTO data)
        {
            try
            {             
                var entity = _mapper.Map<TDTO, T>(data);
           
                _myContext.Set<T>().Update(entity);

                return _myContext.SaveChanges() > 0; 
            }
            catch (Exception ex)
            {          
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }
        public void DetachEntity(T entity)
        {
            _myContext.Entry(entity).State = EntityState.Detached;
        }

        public bool DeleteData(TDTO data)
        {
            try
            {
                _myContext.Set<T>().Remove(_mapper.Map<TDTO, T>(data));
                return _myContext.SaveChanges() > 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public TDTO GetById(Tid id)
        {
            try
            {
                return _mapper.Map<T, TDTO>(_myContext.Set<T>().Find(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
