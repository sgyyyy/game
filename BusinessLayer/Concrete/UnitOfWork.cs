using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataAccessLayer.Abstract.IUnitOfWork _unitOfWork;
        public UnitOfWork(DataAccessLayer.Abstract.IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        private TournamentsManager _tournamentsManager;


        public ITournamentsService Tournaments => _tournamentsManager ??= new TournamentsManager(_unitOfWork);
    }
}
