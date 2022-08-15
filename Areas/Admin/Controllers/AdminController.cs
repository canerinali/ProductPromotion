using Business.Abstract;
using Entities.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace ProductPromotion.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdminController : Controller
    {
        IUserService _userService;
        IWebHostEnvironment _webHostEnvironment;
        IBlogService _blogService;
        IFrequentlyQuestionsService _frequentlyQuestionsService;
        IPhotoService _photoService;
        IHomeService _homeService;

        public AdminController(IUserService userService, IWebHostEnvironment webHostEnvironment, IBlogService blogService, IPhotoService photoService, IFrequentlyQuestionsService frequentlyQuestionsService, IHomeService homeService)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _blogService = blogService;
            _photoService = photoService;
            _frequentlyQuestionsService = frequentlyQuestionsService;
            _homeService = homeService;
        }
        [Route("panel")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            return View(userId);
        }
        [HttpGet, Route("panel/homebannermanagement")]
        public IActionResult HomeBannerManagement()
        {
            return View(_homeService.GetAll());
        }
        [HttpGet, Route("panel/createhomebanner")]
        public IActionResult HomeBannerCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost, Route("panel/createhomebanner")]
        public IActionResult HomeBannerCreate(Home home)
        {
            if (!ModelState.IsValid)
                return View(home);

            var wwwRootPath = _webHostEnvironment.WebRootPath;
            var fileName = new String(Path.GetFileNameWithoutExtension(home.ImagesFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            home.HomeImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(home.ImagesFile.FileName);
            var path = Path.Combine(wwwRootPath + "/images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                home.ImagesFile.CopyTo(fileStream);
            }
            _homeService.Create(home);

            return RedirectToAction("HomeBannerManagement");
        }
        [HttpGet, Route("panel/homebanneredit")]
        public IActionResult HomeBannerEdit(Guid id)
        {
            Home banner = _homeService.GetById(id);
            ViewBag.PhotoId = _photoService.GetAll();
            return View(banner);
        }

        [HttpPost, Route("panel/homebanneredit")]
        public IActionResult HomeBannerEdit(Home banner)
        {
            banner.ModifiedName = "system";
            banner.ModifiedOn = DateTime.Now;
            banner.CreatedOn = DateTime.Now;
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            ViewBag.PhotoId = _photoService.GetAll(x => x.ProductID == banner.Id);

            if (!ModelState.IsValid)
                return View(banner);
            else
            {
                if (banner.ImagesFile != null)
                {
                    var wwwRootPath = _webHostEnvironment.WebRootPath;
                    var fileName = new String(Path.GetFileNameWithoutExtension(banner.ImagesFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                    banner.HomeImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(banner.ImagesFile.FileName);
                    var path = Path.Combine(wwwRootPath + "/images", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        banner.ImagesFile.CopyTo(fileStream);
                    }
                }
            }

            _homeService.Update(banner);

            return RedirectToAction("BlogManagement");
        }
        [HttpGet, Route("panel/sssmanagement")]
        public IActionResult SSSManagement()
        {
            return View(_frequentlyQuestionsService.GetAll());
        }
        [HttpGet, Route("panel/createsss")]
        public IActionResult SSSCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost, Route("panel/createsss")]
        public IActionResult SSSCreate(FrequentlyQuestions frequentlyQuestions)
        {
            if (!ModelState.IsValid)
                return View(frequentlyQuestions);

            _frequentlyQuestionsService.Create(frequentlyQuestions);

            return RedirectToAction("SSSManagement");
        }
        [HttpGet, Route("panel/sssedit")]
        public IActionResult SSSEdit(Guid id)
        {
            FrequentlyQuestions frequentlyQuestions = _frequentlyQuestionsService.GetById(id);
            return View(frequentlyQuestions);
        }

        [HttpPost, Route("panel/sssedit")]
        public IActionResult SSSEdit(FrequentlyQuestions frequentlyQuestions)
        {
            frequentlyQuestions.ModifiedName = "system";
            frequentlyQuestions.ModifiedOn = DateTime.Now;
            frequentlyQuestions.CreatedOn = DateTime.Now;

            if (!ModelState.IsValid)
                return View(frequentlyQuestions);

            _frequentlyQuestionsService.Update(frequentlyQuestions);

            return RedirectToAction("SSSManagement");
        }
        [HttpGet, Route("panel/blog")]
        public IActionResult BlogManagement()
        {
            return View(_blogService.GetAll());
        }
        [HttpGet, Route("panel/createblog")]
        public IActionResult BlogCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost, Route("panel/createblog")]
        public IActionResult BlogCreate(Blog blog)
        {
            if (!ModelState.IsValid)
                return View(blog);

            var wwwRootPath = _webHostEnvironment.WebRootPath;
            var fileName = new String(Path.GetFileNameWithoutExtension(blog.ImagesFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            blog.BlogImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(blog.ImagesFile.FileName);
            var path = Path.Combine(wwwRootPath + "/images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                blog.ImagesFile.CopyTo(fileStream);
            }
            _blogService.Create(blog);

            return RedirectToAction("BlogManagement");
        }
        [HttpGet, Route("panel/blogedit")]
        public IActionResult BlogEdit(Guid id)
        {
            Blog blog = _blogService.GetById(id);
            ViewBag.PhotoId = _photoService.GetAll();
            return View(blog);
        }

        [HttpPost, Route("panel/blogedit")]
        public IActionResult BlogEdit(Blog blog)
        {
            blog.ModifiedName = "system";
            blog.ModifiedOn = DateTime.Now;
            blog.CreatedOn = DateTime.Now;
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            ViewBag.PhotoId = _photoService.GetAll(x => x.ProductID == blog.Id);

            if (!ModelState.IsValid)
                return View(blog);
            else
            {
                if (blog.ImagesFile != null)
                {
                    var wwwRootPath = _webHostEnvironment.WebRootPath;
                    var fileName = new String(Path.GetFileNameWithoutExtension(blog.ImagesFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                    blog.BlogImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(blog.ImagesFile.FileName);
                    var path = Path.Combine(wwwRootPath + "/images", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        blog.ImagesFile.CopyTo(fileStream);
                    }
                }
            }

            _blogService.Update(blog);

            return RedirectToAction("BlogManagement");
        }
        public IActionResult DeleteBlog(Guid id)
        {
            var entity = _blogService.GetById(id);

            if (entity != null)
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                var path = Path.Combine(wwwRootPath + "/images", entity.BlogImage);
                System.IO.File.Delete(path);

                _blogService.Delete(entity);
            }

            return RedirectToAction("Index");
        }
        public IActionResult DeleteSSS(Guid id)
        {
            var entity = _frequentlyQuestionsService.GetById(id);

            if (entity != null)
            {
                _frequentlyQuestionsService.Delete(entity);
            }

            return RedirectToAction("Index");
        }
        public IActionResult DeleteHomeBanner(Guid id)
        {
            var entity = _homeService.GetById(id);

            if (entity != null)
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                var path = Path.Combine(wwwRootPath + "/images", entity.HomeImage);
                System.IO.File.Delete(path);

                _homeService.Delete(entity);
            }

            return RedirectToAction("Index");
        }
    }
}
