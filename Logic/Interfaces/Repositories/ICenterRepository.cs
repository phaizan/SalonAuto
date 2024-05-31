﻿using Storage.Database;
using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces.Repositories
{
    public interface ICenterRepository
    {
        Center Create(DataContext dataContext, Center center);
        Center Update(DataContext dataContext, Center center);
        void Delete(DataContext dataContext, Guid isnNode);
        Center GetById(DataContext dataContext, Guid isnNode);
    }
}
