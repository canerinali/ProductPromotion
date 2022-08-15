using Business.Abstract;
using Entities.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace ProductPromotion.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("panel/user")]
        public IActionResult Index()
        {
            var result = _userService.GetAll();
            return View(result);
        }

        [HttpGet, Route("panel/usercreate")]
        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpPost, Route("panel/usercreate")]
        public IActionResult UserCreate(User user)
        {

            if (!ModelState.IsValid)
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                var fileName = new String(Path.GetFileNameWithoutExtension(user.ImageFile.FileName).Take(10).ToArray()).Replace(' ','-');
                user.ProfileImageFilename = fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(user.ImageFile.FileName); ;
                var path = Path.Combine(wwwRootPath + "/images", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    user.ImageFile.CopyTo(fileStream);
                }

                _userService.Create(user);

                return RedirectToAction("Index");
            }


            return View(user);
        }

        [HttpGet, Route("panel/userdelete")]
        public IActionResult UserDelete()
        {
            return View();
        }

        [HttpPost, Route("panel/userdelete")]
        public IActionResult UserDelete(User user)
        {
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", user.ProfileImageFilename);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            _userService.Delete(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
