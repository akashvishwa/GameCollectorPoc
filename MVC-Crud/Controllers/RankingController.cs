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
                       join g in _context.tbl_Games on r.Id equals g.Id
                       join p in _context.tbl_GamerProfile on r.ProfileId equals p.ProfileId
                       orderby g.Id
                       select new { 
                       
                           ProfileId = p.ProfileId,
                           GamerName=p.GamerName,
                           RankId = r.RankId,
                           Rank=r.Rank,
                           GameId=g.Id,
                           GameName=g.NameOfGame
                       
                       } ;

            ViewBag.Data = data;

            return View();
        }


        public async Task<IActionResult> EditRank(GameRankProfile data) {

            Ranking obj=new Ranking();

            obj.RankId = data.RankId;
            obj.Rank = data.Rank;
            obj.Id = data.Id;
            obj.ProfileId = data.ProfileId;


            _context.Update(obj);
            
            await _context.SaveChangesAsync();

        
            return RedirectToAction("Index","Ranking");
        
        }


        // for sending the data to the form about profiles available and games available
        [HttpGet]
        public async Task<IActionResult> FetchGamerData() {

            var data = from gp in _context.tbl_GamerProfile
                       select new {
                       ProfileId=gp.ProfileId,
                       GamerName=gp.GamerName,
                       
                       };

            return Json(data);
        
        }

        [HttpGet]
        public async Task<IActionResult> FetchGameData()
        {
            var data = from g in _context.tbl_Games
                       select new {
                           Id = g.Id,
                           GameName = g.NameOfGame,
                       
                       };


            return Json(data);

        }



        [HttpPost]
        public async Task<IActionResult> AddRank(Ranking data) {

            _context.tbl_Ranking.Add(data);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteRank(int id) {

            var data=_context.tbl_Ranking.Find(id);
            if (data != null) 
            _context.tbl_Ranking.Remove(data);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }










    }
}
