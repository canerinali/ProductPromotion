using Business.Abstract;
using Entities.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProductPromotion.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        IPhotoService _photoService;
        IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(ICategoryService categoryService, IPhotoService photoService, IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _photoService = photoService;
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("panel/category")]
        public IActionResult Index()
        {
            var category = _categoryService.GetAll();
            return View(category);
        }
        [HttpGet, Route("panel/categorycreate")]
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost, Route("panel/categorycreate")]
        public IActionResult CategoryCreate(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            var wwwRootPath = _webHostEnvironment.WebRootPath;
            var fileName = new String(Path.GetFileNameWithoutExtension(category.ImagesFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            category.CategoryImageFilename = fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(category.ImagesFile.FileName);
            var path = Path.Combine(wwwRootPath + "/images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                category.ImagesFile.CopyTo(fileStream);
            }
            _categoryService.Create(category);

            return RedirectToAction("Index");
        }

        [HttpGet, Route("panel/categoryedit")]
        public IActionResult CategoryEdit(Guid id)
        {
            Category category = _categoryService.GetById(id);
            ViewBag.PhotoId = _photoService.GetAll();
            return View(category);
        }

        [HttpPost, Route("panel/categoryedit")]
        public IActionResult CategoryEdit(Category category)
        {
            category.ModifiedName = "system";
            category.ModifiedOn = DateTime.Now;
            category.CreatedOn = DateTime.Now;
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            ViewBag.PhotoId = _photoService.GetAll(x => x.ProductID == category.Id);

            if (!ModelState.IsValid)
                return View(category);
            else
            {
                if (category.ImagesFile != null)
                {
                    var wwwRootPath = _webHostEnvironment.WebRootPath;
                    var fileName = new String(Path.GetFileNameWithoutExtension(category.ImagesFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                    category.CategoryImageFilename = fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(category.ImagesFile.FileName);
                    var path = Path.Combine(wwwRootPath + "/images", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        category.ImagesFile.CopyTo(fileStream);
                    }
                }

            }
            _categoryService.Update(category);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(Guid id)
        {
            var entity = _categoryService.GetById(id);

            if (entity != null)
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                var path = Path.Combine(wwwRootPath + "/images", entity.CategoryImageFilename);
                System.IO.File.Delete(path);

                _categoryService.Delete(entity);
            }

            return RedirectToAction("Index");
        }


    }
}
