using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quotes.DAL.Repository;
using Quotes.Models;
using Quotes.Models.ViewModel;
using Quotes.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quotes.Web.Controllers
{
    [Area("Author")]
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<AuthorModel> list = _unitOfWork.Author.GetAll();
            return View(list);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AuthorModel obj)
        {
            //todo :: check if author exist
            obj.CreatedTime = DateTime.Now.TimeOfDay;
            if (ModelState.IsValid)
            {
                _unitOfWork.Author.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Author added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Edit(long id)
        {
            var model = _unitOfWork.Author.Get(id);
           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AuthorModel obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Author.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Author updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Remove(long Id)
        {
            var author = _unitOfWork.Author.Get(Id);
            _unitOfWork.Author.Remove(author);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }


        public ActionResult AuthorPartialView()
        {
            IEnumerable<AuthorModel> list = _unitOfWork.Author.GetAll();

            return PartialView("_authors", list);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

