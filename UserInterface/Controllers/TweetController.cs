using System.Web.Mvc;
using Commands;
using ReadModel;
using UserInterface.Commanding;
using System.Linq;

namespace UserInterface.Controllers
{
    public class TweetController : Controller
    {
        public ActionResult Index()
        {
            var context = new ReadModelDataContext();
            var items = from item in context.TweetIndexItems
                         orderby item.TimeStamp descending
                         select item;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(PostNewTweetCommand command)
        {
            var service = new SimpleTwitterCommandServiceClient();
            service.Execute(command);
            return RedirectToAction("Index");
        }
    }
}
