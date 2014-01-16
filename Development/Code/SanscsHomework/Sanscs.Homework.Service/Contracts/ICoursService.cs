using Sanscs.Homework.Model;
using System.Collections.Generic;

namespace Sanscs.Homework.Service.Contracts
{
    public interface ICoursService
    {
        List<cours> GetCoursCategories();
    }
}
