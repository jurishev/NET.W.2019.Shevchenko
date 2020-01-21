using System.Linq;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private ImageContext db = new ImageContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Images.ToList());
        }
    }
}