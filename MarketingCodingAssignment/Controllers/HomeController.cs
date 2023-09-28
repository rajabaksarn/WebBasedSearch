using MarketingCodingAssignment.Models;
using MarketingCodingAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data;
using Microsoft.Extensions.Caching.Memory;
using static System.Net.Mime.MediaTypeNames;

namespace MarketingCodingAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SearchEngine _searchEngine;
        private readonly IMemoryCache _cache;   //Added for store the data in system memory for some time , we can define the time/duration ,now we we set time for 120Sec 1Minuts -(This quick search)
        public static IWebHostEnvironment _environment; //Added for access the movies.csv file from wwwrrot directory.

        //DI Constructor 
        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache, IWebHostEnvironment environment)
        {
            _logger = logger;
            _searchEngine = new SearchEngine();

            _cache = memoryCache; //Fast search or get records  
            _environment = environment; //Access the movies.csv file from wwwroot directory.
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetCSVData(string searchData, JqueryDatatableParam param)
        {
            List<FilmDetails> filmDetails = new List<FilmDetails>();
            bool isExist = _cache.TryGetValue("FilmCache", out filmDetails);
            if (!isExist)
            {
                string path = _environment.WebRootPath;
                path += @"\Files\movies.csv";
                DataTable csvData = GetData.ConvertCSVtoDataTable(path); //Read csv file and store in DataTable from this function .
                filmDetails = (from DataRow dr in csvData.Rows
                               select new FilmDetails()
                               {
                                   id = Convert.ToString(dr["id"]),
                                   budget = Convert.ToString(dr["budget"]),
                                   genres = Convert.ToString(dr["genres"]),
                                   original_language = Convert.ToString(dr["original_language"]),
                                   overview = Convert.ToString(dr["overview"]),
                                   popularity = Convert.ToString(dr["popularity"]),
                                   production_companies = Convert.ToString(dr["production_companies"]),
                                   release_date = Convert.ToString(dr["release_date"]),
                                   revenue = Convert.ToString(dr["revenue"]),
                                   runtime = Convert.ToString(dr["runtime"]),
                                   tagline = Convert.ToString(dr["tagline"]),
                                   title = Convert.ToString(dr["title"]),
                                   vote_average = Convert.ToString(dr["vote_average"]),
                                   vote_count = Convert.ToString(dr["vote_count"])
                               }).ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
           .SetSlidingExpiration(TimeSpan.FromSeconds(120));

                _cache.Set("FilmCache", filmDetails, cacheEntryOptions);
            }


            if (!string.IsNullOrEmpty(searchData))
            {
                filmDetails = filmDetails
                  .Where(x => x.id.Contains(searchData) || x.budget.Contains(searchData) || x.genres.Contains(searchData) || x.original_language.Contains(searchData) || x.overview.Contains(searchData) || x.popularity.Contains(searchData) || x.production_companies.Contains(searchData) || x.release_date.Contains(searchData) || x.revenue.Contains(searchData) || x.runtime.Contains(searchData) || x.tagline.Contains(searchData) || x.title.Contains(searchData) || x.vote_average.Contains(searchData) || x.vote_count.Contains(searchData)).ToList();
            }

            var displayResult = filmDetails.Skip(param.iDisplayStart)
            .Take(param.iDisplayLength).ToList();
            var totalRecords = filmDetails.Count();
            return Json(new
            {
                param.sEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = displayResult
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void PopulateIndex()
        {
            // Sample Data
            var films = new List<Film> {
                new Film {Id = "Film123", Title = "Test Title 1", Overview = "Test Desc 1" },
                new Film {Id = "Film456", Title = "Test Title 2", Overview = "Test Desc 2" },
                new Film {Id = "Film789", Title = "Test Title 3", Overview = "Test Desc 3" }
            };

            _searchEngine.PopulateIndex(films);
            return;
        }

        //[HttpPost]
        public JsonResult Search(String searchString)
        {
            return Json(_searchEngine.Search(searchString));
        }

        public void DeleteIndexContents()
        {
            _searchEngine.DeleteIndexContents();
            return;
        }

    }
}