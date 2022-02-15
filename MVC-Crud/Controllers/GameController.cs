 using Microsoft.AspNetCore.Mvc;

namespace MVC_Crud.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Games> data = _context.tbl_Games.ToList();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddGames(Games game)
        {
            await _context.tbl_Games.AddAsync(game);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> editgames(Games game)
        {

            Console.WriteLine(game.Id);
            var data = _context.tbl_Games.Find(game.Id);

            if (data == null)
                return BadRequest("Please Give correct Id");

            data.NameOfGame = game.NameOfGame;
            data.NoOfLevel = game.NoOfLevel;
            data.Publisher = game.Publisher;
            data.Popularity = game.Popularity;


            await _context.SaveChangesAsync();

             

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteData(int Id) {

            

            var data =await _context.tbl_Games.FindAsync(Id);

            _context.tbl_Games.Remove(data);
            await _context.SaveChangesAsync() ;

            return RedirectToAction("Index");
        }

    }
}
