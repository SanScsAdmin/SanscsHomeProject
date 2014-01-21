using Sanscs.Homework.DAL.Implementations;
using Sanscs.Homework.DAL.Contracts;
using Sanscs.Model;

namespace Sanscs.Homework.Repository
{
    public class QuestionRepository : Repository<question>, IQuestionRepository
    {
        public QuestionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IQuestionRepository : IRepository<question>
    {
    }
}
