using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Database;
using Logic.DtoModels.Filters;
using Logic.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Storage.Models;

namespace Logic.Services
{
    /*public class CenterService : ICenterService
    {
        public IQueryable<Center> GetCenterQueryble(DataContext dataContext, CenterFilterDto filterm, bool asNoTracking)
        {
            IQueryable<Center> query = dataContext.Centers;
            if (asNoTracking)
                query = query.AsNoTracking();
            if (string.IsNullOrEmpty(filterm.Code))
                query = query.Where(x => x.Code == filterm.Code);

            return query;
        }
    }*/
}
