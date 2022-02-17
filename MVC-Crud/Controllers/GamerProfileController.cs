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
                rank => rank.Id,
                game => game.Id,
                (rank, game) => new {
                    ProfId = rank.ProfileId,
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


            return View("Index",data);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(GamerProfile obj) {

             _context.tbl_GamerProfile.Update(obj);

            await _context.SaveChangesAsync();

            return Index(obj.ProfileId);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfile(GamerProfile obj)
        {

            await _context.tbl_GamerProfile.AddAsync(obj);

            await _context.SaveChangesAsync();

            return Index(obj.ProfileId);
        }




    }
}
