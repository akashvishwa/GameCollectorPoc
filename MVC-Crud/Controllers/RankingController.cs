using Microsoft.AspNetCore.Mvc;

namespace MVC_Crud.Controllers
{
    public class RankingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RankingController(ApplicationDbContext context )
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = from r in _context.tbl_Ranking
                       join g in _context.tbl_Games on r.Games.Id equals g.Id
                       join p in _context.tbl_GamerProfile on r.GamerProfile.ProfileId equals p.ProfileId
                       select new { 
                       
                           ProfileId = p.ProfileId,
                           GamerName=p.GamerName,
                           RankId = r.RankId,
                           Rank=r.Rank,
                           GameId=g.Id,
                           GameName=g.NameOfGame
                       
                       };

            ViewBag.Data = data;

            return View();
        }


         

        

        
        
    }
}
