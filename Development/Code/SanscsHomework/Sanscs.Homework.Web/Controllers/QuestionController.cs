using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sanscs.Homework.Service.Contracts;
using Sanscs.Homework.Model.DTO;
using Sanscs.Common.Helpers;
using Sanscs.Homework.Common.Filters;

namespace Sanscs.Homework.WebAPI.Controllers
{
    [EnableCors]
    public class QuestionController : ApiController
    {
        IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        // GET api/question
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/question/5
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/question
        //public void Post()
        //{

        //}

        // PUT api/question/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/question/5
        public void Delete(int id)
        {
        }
        public void Post()
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                var streamProvider = new MultipartFormDataStreamProvider("E:/uploads/");
                var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
                    {
                        if (t.IsFaulted || t.IsCanceled)
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                    });
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }

        public void SaveExamHistory(ExamHistoryDTO history)
        {
            _questionService.AddExamHistory(history);
        }
        public IEnumerable<QuestionDTO> GetQuestions()
        {
           return _questionService.GetQuestions();
        }
       public string GetAnswer(int ID)
        {
            return _questionService.GetAnswer(ID);
        }
    }
}
