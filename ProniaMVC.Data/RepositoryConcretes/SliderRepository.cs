using ProniaMVC.Core.Models;
using ProniaMVC.Core.RepositoryAbstracts;
using ProniaMVC.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Data.RepositoryConcretes
{
    public class SliderRepository : GenericRepository<Slider>, ISliderRepository
    {
        public SliderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
