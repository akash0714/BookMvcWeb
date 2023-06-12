﻿using BookMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMvc.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        void Update(Product product);
    }
}