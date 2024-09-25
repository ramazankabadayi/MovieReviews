using MovieReviewsEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviewsDL;
using Microsoft.EntityFrameworkCore;

namespace MovieReviewsBL
{
    public class UserManager
    {
        private readonly MyContext _context;

        public UserManager(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
