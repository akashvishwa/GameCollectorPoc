using Microsoft.AspNetCore.Mvc;

namespace MVC_Crud.Controllers
{
    public class GamerProfileController : Controller
    {

        private readonly ApplicationDbContext _context;

        public GamerProfileController(ApplicationDbContext context)
        {
            _context=context;
        }

        [HttpGet]
        public IActionResult Index(int id=1)
        {
            var data = _context.tbl_GamerProfile.Find(id);


            //filtering table data
            var tdata = _context.tbl_Ranking.Join(_context.tbl_Games,
                rank => rank.Games.Id,
                game => game.Id,
                (rank, game) => new {
                    ProfId = rank.GamerProfile.ProfileId,
                    RankId = rank.RankId,
                    Rank = rank.Rank,
                    GameId = game.Id,
                    NameOfGame = game.NameOfGame,
                    NoOfLevels = game.NoOfLevel,
                    Publisher = game.Publisher,
                    Popularity = game.Popularity,

                }
                ).Where(fdata => fdata.ProfId == id);   /*fdata refers to filtered data , performing a join & where operartion simoultaneously*/

            ViewBag.tdata = tdata;


            return View(data);
        }

       

    }
}
