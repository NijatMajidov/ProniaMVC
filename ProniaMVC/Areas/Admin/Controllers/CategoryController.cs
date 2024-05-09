using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaMVC.Business.Exceptions;
using ProniaMVC.Business.Services.Abstracts;
using ProniaMVC.Core.Models;

namespace ProniaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {   
        private readonly ICategoryService _categoryService;
        
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            { 
                return View(); 
            }
            try
            {
                _categoryService.AddCategory(category);
            }
            catch (DublicateCategoryException ex)
            {
                ModelState.AddModelError(ex.PropertyName,ex.Message);
                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "An error occurred while creating the category.");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var category = _categoryService.GetCategory(x=>x.Id==id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }

            return View(category);


        }

        [HttpPost]
        public IActionResult Update(Category updatedCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedCategory);
            }

            try
            {
                _categoryService.UpdaterCategory(1, updatedCategory);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating the category.");
                return View(updatedCategory);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while deleting the category.");
                return RedirectToAction("Index");
            }
        }

    }
}
