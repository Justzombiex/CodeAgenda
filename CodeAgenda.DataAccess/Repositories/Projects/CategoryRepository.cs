﻿using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.DataAccess.Repositories
{
    public class CategoryRepository
        : RepositoryBase, ICategoryRepository
    {

        public CategoryRepository(ApplicationContext context) : base(context)
        {
        }

        public void Add(Category Category)
        {
            _context.Category.Add(Category);
        }

        Category? ICategoryRepository.GetById(Guid id)
        {
            var category = _context.Category.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public void Update(Category Category)
        {
            _context.Category.Update(Category);
        }

        public void Delete(Category Category)
        {
            _context.Category.Remove(Category);
        }
    }
}
