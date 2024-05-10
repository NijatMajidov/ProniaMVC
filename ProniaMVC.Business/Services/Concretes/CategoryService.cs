using ProniaMVC.Business.Exceptions;
using ProniaMVC.Business.Services.Abstracts;
using ProniaMVC.Core.Models;
using ProniaMVC.Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Business.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void CreateCategory(Category category)
        {
            if (category == null) throw new NullReferenceException("Category cannot be null!!!!");
            if (!_categoryRepository.GetAll().Any(x => x.Name == category.Name))
            {
                _categoryRepository.Add(category);
                _categoryRepository.Commit();
            }
            else throw new DublicateCategoryException("Name","This category is now available!!!");
            
        }

        public void DeleteCategory(int id)
        {
            var existCategory = _categoryRepository.Get(x=> x.Id == id);
            if (existCategory == null) throw new NullReferenceException("This category does not exist!");
            _categoryRepository.Delete(existCategory);
            _categoryRepository.Commit();
        }

        public List<Category> GetAllCategories(Func<Category, bool>? func = null)
        {
            return _categoryRepository.GetAll(func);
        }

        public Category GetCategory(Func<Category, bool>? func = null)
        {
            return _categoryRepository.Get(func);
        }

        public void UpdaterCategory(int id, Category newCategory)
        {
            var existCategory = _categoryRepository.Get(x => x.Id == id);
            if (existCategory == null) throw new NullReferenceException("This category does not exist!");
            if (!_categoryRepository.GetAll().Any(x => x.Name == newCategory.Name))
            {
                existCategory.Name = newCategory.Name;
                _categoryRepository.Commit();
            }
            else throw new DublicateCategoryException("Name","This category is now available!!!");

        }
    }
}
