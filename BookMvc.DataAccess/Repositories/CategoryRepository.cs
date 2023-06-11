using BookMvc.DataAccess.Repositories.Interfaces;
using BookMvc.Models;
using BookMVC.DataAccess.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMvc.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Category entity)
        {
            _dbContext.Categories.Update(entity);
        }
    }
}
