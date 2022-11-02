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
        private readonly DataAccessLayer.Abstract.IUnitOfWork _unitOfWork;
        public TournamentsManager(DataAccessLayer.Abstract.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Create(Tournaments entity)
        {
            var result = _unitOfWork.Tournaments.Create(entity);
            if (result)
                return true;
            return false;
        }

        public bool Delete(Tournaments entity)
        {
            var result = _unitOfWork.Tournaments.Delete(entity);
            if (result)
                return true;
            return false;
        }

        public List<Tournaments> GetAll()
        {
            return _unitOfWork.Tournaments.GetAll();
        }

        public Tournaments GetById(int id)
        {
            return _unitOfWork.Tournaments.GetById(id);
        }

        public bool Update(Tournaments entity)
        {
            var result = _unitOfWork.Tournaments.Update(entity);
            if (result)
                return true;
            return false;
        }
    }
}
