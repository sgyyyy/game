using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfCoreTournamentsRepository : EfCoreGenericRepository<Tournaments>, ITournamentsRepository
    {
        public EfCoreTournamentsRepository(Context context) : base(context)
        {
        }

        private Context Context
        {
            get { return context as Context; }
        }

    }
}
