using GigHub.Models;
using GigHub.ViewModels;
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
    }
}