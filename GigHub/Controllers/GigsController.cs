using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {

        private ApplicationDbContext _context;

        //initialise a constructor
        public GigsController()
        {
            _context = new ApplicationDbContext();


        }
        [Authorize]
        // GET: Gigs
        public ActionResult Create()
        {
            //create a view model and set its Genre properties

            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()

            };

            return View(viewModel);
        }

        [Authorize]  // declare an attribute to make sure authenicated users can call this action
        [HttpPost]  // want this action only to be called by HttpPost 

        // Adding a new object with Entity Framework is as simple as constructing a new instance of your object 
        //and registering it using the Add method on DbSet.

        public ActionResult Create(GigFormViewModel viewModel)
        {

            //var artistId = User.Identity.GetUserId();
            //var artist = _context.Users.Single(u => u.Id == artistId);
            //var genre = _context.Genres.Single(u => u.Id == viewModel.Genre);

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue

            };

            //we have a gig objext which we will need to add to our context
            _context.Gigs.Add(gig);

            // entity framework will generate a sql statement and execute it against my database
            _context.SaveChanges();
            // After save redirect user to home page
            return RedirectToAction("Index", "Home");


        }
    }
}