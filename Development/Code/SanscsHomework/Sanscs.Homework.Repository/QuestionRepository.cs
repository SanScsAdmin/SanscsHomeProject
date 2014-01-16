using Sanscs.Homework.DAL.Implementations;
using Sanscs.Homework.DAL.Contracts;
using Sanscs.Homework.Model;

namespace Sanscs.Homework.Repository
{
    public class QuestionRepository : Repository<question>, IQuestionsRepository
    {
        private SanscsHomeworkPlatformdbEntities dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public QuestionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected SanscsHomeworkPlatformdbEntities DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }


    }
    public interface IQuestionsRepository : IRepository<question>
    {
    }
}
