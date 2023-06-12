using BookMvc.DataAccess.Repositories.Interfaces;
using BookMvc.Models;
using BookMVC.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMvc.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Product product)
        {
            _dbContext.Update(product);
        }
    }
}
