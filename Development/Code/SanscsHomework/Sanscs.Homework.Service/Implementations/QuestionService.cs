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
using Sanscs.Service.Functionalities.Contracts;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;
using Sanscs.Model;
namespace Sanscs.Homework.Service.Implementations
{
    public class QuestionService : IQuestionService
    {
        IUnitOfWork _unitOfWork;
        IExamHistoryRepository _examHistoryRepository;
        IQuestionRepository _questionsRepository;
        IQuestionTransfer _transfer;
        public QuestionService(
            IUnitOfWork unitOfWork,
            IQuestionRepository questionsRepository,
            IExamHistoryRepository examHistoryRepository,
            IQuestionTransfer transfer
            )
        {
            this._unitOfWork = unitOfWork;
            this._questionsRepository = questionsRepository;
            this._examHistoryRepository = examHistoryRepository;
            this._transfer = transfer;
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

            if (questionDTO.ID != 0)
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
        public IEnumerable<QuestionDTO> GetQuestions()
        {
            var data = from q in _questionsRepository.GetAll()
                       select new QuestionDTO
                       {
                           ContentResult = _transfer.GetQuestionContent(q),
                           ID = q.ID
                       };
            return data;

        }
        public QuestionDTO GetQuestionByID(int ID)
        {
            question model = _questionsRepository.GetById(ID);
            return new QuestionDTO
            {
                Content = model.Content,
                Type =model.question_type.name
            };
        }
        public void AddExamHistory(ExamHistoryDTO history)
        {
            _examHistoryRepository.Add(new exam_history
            {
                Questions_ID = history.QuestionID,
                Is_Correct = history.IsCorrect
            });
        }

        public string GetAnswer(int ID)
        {
            question model = _questionsRepository.GetById(ID);
            XPathNavigator nav;
            XPathDocument docNav;
            String strExpression;
            MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(model.Content));
            docNav = new XPathDocument(stream);
            // Create a navigator to query with XPath.
            nav = docNav.CreateNavigator();
            // Find the average cost of a book.
            // This expression uses standard XPath syntax.
            strExpression = "/assessmentItem/responseDeclaration/correctResponse/value";
            XPathExpression xpe = nav.Compile(strExpression);
            XPathNodeIterator data = nav.Select(xpe);
            string answer = string.Empty;
            while (data.MoveNext())
            {
                answer += data.Current.Value+"|||";
            }
           return answer;
        }
    }
}
