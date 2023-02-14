using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quotes.DAL.Repository;
using Quotes.Models;
using Quotes.Models.ViewModel;
using Quotes.Web.Models;
using Quotes.Web.Views.Quote;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quotes.Web.Controllers
{
    [Area("Quote")]
    public class QuoteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuoteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(String? id = null)
        {

            IEnumerable<QuotesModel> list;
            if (id != null)
            {
                long Id;
                long.TryParse(id, out Id);
                list = _unitOfWork.Quote.listQuotes(Id);
            }
            else
                list = _unitOfWork.Quote.listQuotes();

            List<SelectListItem> authorsList = _unitOfWork.Author.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }).ToList();

            IndexModel model = new IndexModel
            {
                Quotes=list,
                Authors= authorsList,
                AuthorId= id!=null?int.Parse(id):0
            };
            return View(model);
         
        }


        public IActionResult Create()
        {
            CreateQuotesVM vm = new()
            {
                Authors = _unitOfWork.Author.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList(),
                
            };
            return View(vm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateQuotesVM obj)
        {           
            if (ModelState.IsValid)
            {
                QuotesModel model = new QuotesModel
                {
                    AuthorId=obj.AuthorId,
                    Text=obj.Text,
                    CreatedTime = DateTime.Now.TimeOfDay

                };
                _unitOfWork.Quote.Add(model);
                _unitOfWork.Save();
                TempData["success"] = "Quote added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        



        public ActionResult QuotePartialView(String? authorId = null)
        {
            IEnumerable<QuotesModel> list;
            if (authorId != null)
            {
                long Id;
                long.TryParse(authorId, out Id);
                list = _unitOfWork.Quote.listQuotes(Id);
            }
            else
                list = _unitOfWork.Quote.listQuotes();

            return PartialView("_Quotes", list);
        }

        [HttpGet]
        public JsonResult GetRandomQuote() 
        {
            QuotesModel? quote = _unitOfWork.Quote.GetRandomQuote();
            return Json(quote?.Text);
        }

        [HttpPost]
        public ActionResult Remove(long Id)
        {
            var quote = _unitOfWork.Quote.Get(Id);
            _unitOfWork.Quote.Remove(quote);
            _unitOfWork.Save();

            return QuotePartialView();
        }



        public IActionResult Edit(long id)
        {
            var model = _unitOfWork.Quote.Get(id);
            UpdateQuotesVM vm = new()
            {
                Authors = _unitOfWork.Author.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList(),

                AuthorId=model.AuthorId,
                Text=model.Text,
                CreatedTime= model.CreatedTime

            };
            
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateQuotesVM obj)
        {
            if (ModelState.IsValid)
            {
                QuotesModel model = new QuotesModel
                {
                    AuthorId = obj.AuthorId,
                    Text = obj.Text,
                    CreatedTime = DateTime.Now.TimeOfDay,
                    Id=obj.Id

                };

                _unitOfWork.Quote.Update(model);
                _unitOfWork.Save();
                TempData["success"] = "Quotes updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NoDataFound()
        {
            return PartialView("_NoDataFound");
        }


    }
}

