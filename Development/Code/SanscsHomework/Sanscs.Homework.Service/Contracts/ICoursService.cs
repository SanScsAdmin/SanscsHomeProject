using Sanscs.Homework.Model;
using System.Collections.Generic;
using Sanscs.Model;

namespace Sanscs.Homework.Service.Contracts
{
    public interface ICoursService
    {
        List<cours> GetCoursCategories();
    }
}
