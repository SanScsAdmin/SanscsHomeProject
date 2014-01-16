using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanscs.Homework.Model.DTO;

namespace Sanscs.Homework.Service.Contracts
{
    public interface IQuestionService
    {
        int SaveOrUpdateQuestion(QuestionDTO question);
    }
}
