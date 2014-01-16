using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanscs.Homework.Service.Contracts;
using Sanscs.Homework.Model.DTO;
using Sanscs.Homework.Model;
using Sanscs.Homework.DAL.Contracts;
using Sanscs.Homework.Repository;
namespace Sanscs.Homework.Service.Implementations
{
    public class QuestionService : IQuestionService
    {
        IUnitOfWork _unitOfWork;
        IQuestionsRepository _questionsRepository;

        public QuestionService(
            IUnitOfWork unitOfWork,
            IQuestionsRepository questionsRepository)
        {
            this._unitOfWork = unitOfWork;
            this._questionsRepository = questionsRepository;
        }

        public int SaveOrUpdateQuestion(QuestionDTO questionDTO)
        {
            question question;
            if (questionDTO.ID != 0)
                question = _questionsRepository.GetById(questionDTO.ID);
            else
                question = new question();

            question.Content = questionDTO.Content;
            question.Question_Number = questionDTO.QuestionNumber;
            question.Solution = questionDTO.Solution;
            question.Tips = questionDTO.Tips;

            if (questionDTO.ID!=0)
            {
                _questionsRepository.Update(question);
            }
            else
            {
                _questionsRepository.Add(question);
            }
            _unitOfWork.Commit();
            return question.ID;
        }

    }
}
