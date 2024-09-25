using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReviewsBL;
using MovieReviewsDL;
using MovieReviewsEL.DTO;
using MovieReviewsEL.Entities;
using WebUI.Models;

public class FilmController : Controller
{
    public readonly BaseManager<Film, FilmDTO, int> _filmManager;
    public readonly BaseManager<Review, ReviewDTO, int> _reviewManager;
    public readonly IMapper _mapper;

    public FilmController(BaseManager<Film, FilmDTO, int> filmManager, BaseManager<Review, ReviewDTO, int> reviewManager, IMapper mapper)
    {
        _filmManager = filmManager ?? throw new ArgumentNullException(nameof(filmManager));
        _reviewManager = reviewManager ?? throw new ArgumentNullException(nameof(reviewManager));
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var films = _filmManager.GetAllData();
        return View(films);
    }

    public IActionResult Details(int id)
    {
        var film = _filmManager.GetById(id);

        if (film == null)
        {
            return NotFound();
        }

        var reviews = _reviewManager.GetSomeData(r => r.FilmId == id, r => r.User, r => r.Film)
                      ?? new List<ReviewDTO>();

        var filmDetailsViewModel = new FilmDetailsViewModel
        {
            Film = film,
            Reviews = reviews
        };

        return View(filmDetailsViewModel);
    }


    public IActionResult Create()
        {
            return View();
        }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FilmDTO filmDto, IFormFile coverImageFile)
    {
        ModelState.Remove("CoverImagePath");
        if (ModelState.IsValid)
        {
            if (coverImageFile != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                Directory.CreateDirectory(uploadsFolder);
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + coverImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await coverImageFile.CopyToAsync(fileStream);
                }

                filmDto.CoverImagePath = "/images/" + uniqueFileName;
            }

            var filmEntity = _mapper.Map<FilmDTO, Film>(filmDto);
            _filmManager.AddNewData(filmDto);

            return RedirectToAction("Index","Home");
        }
        else
        {
            foreach (var modelStateEntry in ModelState.Values)
            {
                foreach (var error in modelStateEntry.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(filmDto);
        }

        
    }


}


