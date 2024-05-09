global using ProniaMVC.Core.Models;
global using ProniaMVC.Core.RepositoryAbstracts;
global using ProniaMVC.Data.DAL;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;

namespace ProniaMVC.Data.RepositoryConcretes;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
