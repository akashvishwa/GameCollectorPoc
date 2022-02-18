using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;


namespace MVC_Crud.Controllers
{
    public class GamerProfileController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public GamerProfileController(ApplicationDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context=context;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index(int id=1)
        {
            var data = _context.tbl_GamerProfile.Find(id);

            //changing type to view modal
            GamerPrUpload newProf=new GamerPrUpload();
            newProf.ProfileId=data.ProfileId;
            newProf.RealName=data.RealName;
            newProf.GamerName=data.GamerName;
            newProf.Gender=data.Gender;
            newProf.GamingDevice=data.GamingDevice;
            newProf.IsEsportPlayer=data.IsEsportPlayer;
            newProf.Email=data.Email;
            newProf.GamingPlatformId=data.GamingPlatformId;



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
            ViewBag.PicturePath = data.PhotoPath;


            return View("Index",newProf);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(GamerPrUpload model) {

            string UniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                UniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string FilePath = Path.Combine(uploadsFolder, UniqueFileName);
                model.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));
            }


            GamerProfile gp = new GamerProfile
            {
                ProfileId = model.ProfileId,
                RealName = model.RealName,
                GamerName = model.GamerName,
                Gender = model.Gender,
                GamingDevice = model.GamingDevice,
                IsEsportPlayer = model.IsEsportPlayer,
                Email = model.Email,
                GamingPlatformId = model.GamingPlatformId,
                PhotoPath = UniqueFileName

            };

            _context.tbl_GamerProfile.Update(gp);

            await _context.SaveChangesAsync();

            return Index(gp.ProfileId);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfile(GamerPrUpload model)
        {

            

                string UniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    UniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string FilePath = Path.Combine(uploadsFolder, UniqueFileName);
                    model.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));
                }


                GamerProfile gp = new GamerProfile
                {
                    ProfileId = model.ProfileId,
                    RealName = model.RealName,
                    GamerName = model.GamerName,
                    Gender = model.Gender,
                    GamingDevice = model.GamingDevice,
                    IsEsportPlayer = model.IsEsportPlayer,
                    Email = model.Email,
                    GamingPlatformId = model.GamingPlatformId,
                    PhotoPath = UniqueFileName

                };

                await _context.tbl_GamerProfile.AddAsync(gp);

                await _context.SaveChangesAsync();

                return Index(gp.ProfileId);
               
            

            
        }

        // just for returning the gamer profile form
        public IActionResult AddProfileForm() {

            return View("AddGamerProfileForm");
        }



        [HttpGet]
        public async Task<IActionResult> DeleteProfile(int id) {
            var data = _context.tbl_GamerProfile.Find(id);

            /*var filepath = Path.Combine(hostingEnvironment.WebRootPath, data.PhotoPath);
            // code for deleting the file
            
            try 
            {
                System.IO.File.Delete(filepath);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/


            if (data != null) 
                _context.tbl_GamerProfile.Remove(data);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index","Ranking");
        }




    }
}
