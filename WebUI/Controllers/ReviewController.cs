using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieReviewsBL;
using MovieReviewsEL.DTO;
using MovieReviewsEL.Entities;
using System.Linq;

namespace WebUI.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly ReviewManager _reviewManager;
        private readonly BaseManager<Film, FilmDTO, int> _filmManager;
        private readonly BaseManager<User, UserDTO, int> _userManager;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _aspUserManager;

        public ReviewController(
            ReviewManager reviewManager,
            BaseManager<Film, FilmDTO, int> filmManager,
            BaseManager<User, UserDTO, int> userManager,
            IMapper mapper,
            UserManager<IdentityUser> aspUserManager)
        {
            _reviewManager = reviewManager;
            _filmManager = filmManager;
            _userManager = userManager;
            _mapper = mapper;
            _aspUserManager = aspUserManager;
        }

        [HttpGet]
        public IActionResult Create(int filmId)
        {
            var review = new ReviewDTO { FilmId = filmId };
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(ReviewDTO reviewDto)
        {
            ModelState.Remove("Film");
            ModelState.Remove("User");

            if (!ModelState.IsValid)
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(reviewDto);
            }

            if (ModelState.IsValid)
            {
                reviewDto.ReviewDate = DateTime.Now;

                string username = User.Identity.Name;
                var identityUser = await _aspUserManager.FindByEmailAsync(User.Identity.Name);
                if (identityUser == null)
                {
                    return Unauthorized();
                }


                var existingUser = _userManager.GetSomeData(u => u.Username == username).FirstOrDefault();

                if (existingUser == null)
                {
                    var newUser = new UserDTO
                    {
                        Username = identityUser.UserName,
                        Email = identityUser.Email
                    };
                    _userManager.AddNewData(newUser);
                    reviewDto.UserId = newUser.UserId;
                }
                else
                {
                    reviewDto.UserId = existingUser.UserId;
                }

                var film = _filmManager.GetById(reviewDto.FilmId);
                if (film == null)
                {
                    ModelState.AddModelError(string.Empty, "Film bulunamadı.");
                    return View(reviewDto);
                }

                reviewDto.Film = film;

                _reviewManager.AddNewData(reviewDto);

                return RedirectToAction("Details", "Film", new { id = reviewDto.FilmId });
            }

            return View(reviewDto);
        }
    }
}
