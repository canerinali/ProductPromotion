using Business.Abstract;
using Entities.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductPromotion.Areas.Admin.Models;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace ProductPromotion.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IPhotoService _photoService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductController(IProductService productService, IPhotoService photoService, IUserService userService, ICategoryService categoryService, ICompanyService companyService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _userService = userService;
            _photoService = photoService;
            _categoryService = categoryService;
            _companyService = companyService;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("panel/product")]
        public IActionResult Index()
        {
            var data = new ProductViewModel
            {
                Photo = _photoService.GetAll(),
                Product = _productService.GetAll()
            };

            return View(data);
        }
        public IActionResult PhotoDelete(Guid id, Guid productId)
        {
            var photo = _photoService.GetById(id);
            _photoService.Delete(photo);
            var deletePhotoId = _photoService.Get(x => x.ProductID == id);
            var wwwRootPath = _webHostEnvironment.WebRootPath;
            var path = Path.Combine(wwwRootPath + "/images", photo.ImageUrl);
            System.IO.File.Delete(path);
            return new JavaScriptResult("<script> history.back() </script>");
        }
        public IActionResult DeleteProduct(Guid id)
        {
            var entity = _productService.GetById(id);
            var photo = _photoService.GetAll();

            if (entity != null)
            {
                foreach (var photos in photo)
                {
                    if (photos.ProductID == id)
                    {
                        _photoService.Delete(photos);
                        var wwwRootPath = _webHostEnvironment.WebRootPath;
                        var path = Path.Combine(wwwRootPath + "/images", photos.ImageUrl);
                        System.IO.File.Delete(path);
                    }
                }
                _productService.Delete(entity);
            }

            return RedirectToAction("Index");
        }

        [HttpGet, Route("panel/productedit")]
        public IActionResult ProductEdit(Guid id)
        {
            Product product = _productService.GetById(id);
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(x => x.Id == product.CategoryId), "Id", "Title");
            ViewBag.CompanyId = new SelectList(_companyService.GetAll(x => x.Id == product.CompanyId), "Id", "FirmaName");
            ViewBag.PhotoId = _photoService.GetAll();
            return View(product);
        }

        [HttpPost, Route("panel/productedit")]
        public IActionResult ProductEdit(Product product)
        {
            product.ModifiedName = "system";
            product.ModifiedOn = DateTime.Now;
            product.CreatedOn = DateTime.Now;
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            product.Owner = _userService.GetById(userId);

            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(x => x.Id == product.CategoryId), "Id", "Title");
            ViewBag.CompanyId = new SelectList(_companyService.GetAll(x => x.Id == product.CompanyId), "Id", "FirmaName");
            ViewBag.PhotoId = _photoService.GetAll(x => x.ProductID == product.Id);
            var cate = _categoryService.GetById(product.CategoryId);

            if (!ModelState.IsValid)
                return View(product);
            else
            {
                if (product.ImagesFile != null)
                {
                    foreach (var imagesFile in product.ImagesFile)
                    {
                        var wwwRootPath = _webHostEnvironment.WebRootPath;
                        var fileName = new String(Path.GetFileNameWithoutExtension(imagesFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                        var photofilePath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imagesFile.FileName);
                        var path = Path.Combine(wwwRootPath + "/images", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            imagesFile.CopyTo(fileStream);
                        }
                        var newPhoto = new Photo()
                        {
                            ProductID = product.Id,
                            ImageUrl = photofilePath
                        };
                        _photoService.Create(newPhoto);
                    }
                }

            }
            _productService.Update(product);

            return RedirectToAction("Index");
        }

        [HttpGet, Route("panel/productcreate")]
        public IActionResult ProductCreate()
        {
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Title");
            ViewBag.CompanyId = new SelectList(_companyService.GetAll(), "Id", "FirmaName");
            return View();
        }

        [HttpPost, Route("panel/productcreate")]
        public IActionResult ProductCreate(Product product)
        {
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "Title");
            ViewBag.CompanyId = new SelectList(_companyService.GetAll(), "Id", "FirmaName");

            if (!ModelState.IsValid)
                return View(product);
            else
            {
                _productService.Create(product);

                if (product.ImagesFile != null)
                {
                    foreach (var imagesFile in product.ImagesFile)
                    {
                        var wwwRootPath = _webHostEnvironment.WebRootPath;
                        var fileName = new String(Path.GetFileNameWithoutExtension(imagesFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                        var photofilePath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imagesFile.FileName);
                        var path = Path.Combine(wwwRootPath + "/images", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            imagesFile.CopyTo(fileStream);
                        }
                        var newPhoto = new Photo()
                        {
                            ProductID = product.Id,
                            ImageUrl = photofilePath
                        };
                        _photoService.Create(newPhoto);
                        _productService.Update(product);
                    }
                }
            }

            return RedirectToAction("Index");
        }
        public class JavaScriptResult : ContentResult
        {
            public JavaScriptResult(string script)
            {
                this.Content = $@"<script src=""~/lib/jquery/dist/jquery.min.js""></script>" + script;
                this.ContentType = "text/html";
            }
        }
    }
}
