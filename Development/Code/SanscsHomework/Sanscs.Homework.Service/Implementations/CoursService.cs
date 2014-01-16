using Sanscs.Homework.DAL.Contracts;
using Sanscs.Homework.Model;
using Sanscs.Homework.Repository;
using Sanscs.Homework.Service.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Application.Service.Implementations
{
    public class CoursService : ICoursService
    {
        IUnitOfWork unitOfWork;
        ICoursRepository _coursRepository;

        public CoursService(
            IUnitOfWork unitOfWork,
            ICoursRepository coursRepository)
        {
            this.unitOfWork = unitOfWork;

            this._coursRepository = coursRepository;
        }

      

        /// <summary>
        /// To fetch all cours
        /// </summary>
        /// <returns></returns>
        public List<cours> GetCoursCategories()
        {
            List<cours> coursCategories;
            coursCategories = _coursRepository.GetAll().ToList();
            return coursCategories;
        }


    }
}
