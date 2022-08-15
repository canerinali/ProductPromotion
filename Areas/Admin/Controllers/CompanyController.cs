using Business.Abstract;
using Entities.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace ProductPromotion.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        ICompanyService _companyService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompanyController(ICompanyService companyService, IWebHostEnvironment webHostEnvironment)
        {
            _companyService = companyService;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("panel/company")]
        public IActionResult Index()
        {
            var category = _companyService.GetAll();
            return View(category);
        }
        [HttpGet, Route("panel/companycreate")]
        public IActionResult CompanyCreate()
        {
            return View();
        }

        [HttpPost, Route("panel/companycreate")]
        public IActionResult CompanyCreate(Company company)
        {
            if (!ModelState.IsValid)
                return View(company);

            if (company.ImagesFile != null)
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                var fileName = new String(Path.GetFileNameWithoutExtension(company.ImagesFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                company.FirmaImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(company.ImagesFile.FileName);
                var path = Path.Combine(wwwRootPath + "/images", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    company.ImagesFile.CopyTo(fileStream);
                }
            }

            _companyService.Create(company);

            return RedirectToAction("Index");
        }

        [HttpGet, Route("panel/companyedit")]
        public IActionResult CompanyEdit(Guid id)
        {
            Company company = _companyService.GetById(id);
            return View(company);
        }

        [HttpPost, Route("panel/companyedit")]
        public IActionResult CompanyEdit(Company company)
        {
            company.ModifiedName = "system";
            company.ModifiedOn = DateTime.Now;
            company.CreatedOn = DateTime.Now;
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);


            if (!ModelState.IsValid)
                return View(company);
            else
            {
                if (company.ImagesFile != null)
                {
                    var wwwRootPath = _webHostEnvironment.WebRootPath;
                    var fileName = new String(Path.GetFileNameWithoutExtension(company.ImagesFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                    company.FirmaImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(company.ImagesFile.FileName);
                    var path = Path.Combine(wwwRootPath + "/images", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        company.ImagesFile.CopyTo(fileStream);
                    }
                }

            }
            _companyService.Update(company);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCompany(Guid id)
        {
            var entity = _companyService.GetById(id);

            if (entity != null)
            {
                if (string.IsNullOrEmpty(entity.FirmaImage))
                {
                    var wwwRootPath = _webHostEnvironment.WebRootPath;
                    var path = Path.Combine(wwwRootPath + "/images", entity.FirmaImage);
                    System.IO.File.Delete(path);
                    var company = new Company()
                    {
                        Id = id,
                        FirmaName = entity.FirmaName,
                        FirmaImage = entity.FirmaImage,
                        Products = entity.Products,
                        CreatedOn = entity.CreatedOn,
                        ModifiedName = entity.ModifiedName,
                        ModifiedOn = DateTime.Now,
                    };
                }

                _companyService.Delete(entity);
            }

            return RedirectToAction("Index");
        }

    }
}
