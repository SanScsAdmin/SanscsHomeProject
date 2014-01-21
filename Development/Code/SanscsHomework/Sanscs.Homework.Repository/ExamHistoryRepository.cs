using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanscs.Homework.DAL.Implementations;
using Sanscs.Homework.DAL.Contracts;
using Sanscs.Model;
namespace Sanscs.Homework.Repository
{
    public class ExamHistoryRepository : Repository<exam_history>, IExamHistoryRepository
    {
        public ExamHistoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IExamHistoryRepository : IRepository<exam_history>
    {
    }
}
