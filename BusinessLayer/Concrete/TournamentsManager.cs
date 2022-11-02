using BusinessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TournamentsManager : ITournamentsService
    {
        private readonly DataLayer.Abstract.IUnitOfWork _unitOfWork;
        public TournamentsManager(DataLayer.Abstract.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Create(Tournaments entity)
        {
            var result = _unitOfWork.Tournamentss.Create(entity);
            if (result)
                return true;
            return false;
        }

        public bool Delete(Tournaments entity)
        {
            var result = _unitOfWork.Tournamentss.Delete(entity);
            if (result)
                return true;
            return false;
        }

        public List<Tournaments> GetAll()
        {
            return _unitOfWork.Tournamentss.GetAll();
        }

        public Tournaments GetById(int id)
        {
            return _unitOfWork.Tournamentss.GetById(id);
        }

        public bool Update(Tournaments entity)
        {
            var result = _unitOfWork.Tournamentss.Update(entity);
            if (result)
                return true;
            return false;
        }
    }
}
