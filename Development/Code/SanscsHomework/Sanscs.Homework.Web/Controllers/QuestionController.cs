using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sanscs.Homework.Service.Contracts;

namespace Sanscs.Homework.WebAPI.Controllers
{
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
        //public int SaveFill( string filename)
        //{

        //    if (Request.Files.Count == 0)
        //    {
        //        //Request.Files.Count 文件数为0上传不成功
        //        return 0;
        //    }

        //    var file = Request.Files[0];
        //    if (file.ContentLength == 0)
        //    {
        //        //文件大小大（以字节为单位）为0时，做一些操作
        //        return 0;
        //    }
        //    else
        //    {
        //        //文件大小不为0
        //        HttpPostedFileBase files = Request.Files[0];
        //        //保存成自己的文件全路径,newfile就是你上传后保存的文件,
        //        //服务器上的UpLoadFile文件夹必须有读写权限　　　　　　
        //        var newFile = filename + ".doc";//"newfile.doc";
        //        files.SaveAs(Server.MapPath(@"\Upload\File\") + newFile);
        //    }

        //    return 1;
        //}
    }
}
