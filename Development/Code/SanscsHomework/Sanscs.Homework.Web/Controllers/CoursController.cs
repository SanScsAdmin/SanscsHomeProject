using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sanscs.Homework.Service.Contracts;
using Sanscs.Model;
using Newtonsoft.Json;
using Sanscs.Homework.Common.Filters;
using Sanscs.Homework.Common.Log;
namespace Sanscs.Homework.WebAPI.Controllers
{
    public class CoursController : ApiController
    {
         ICoursService _coursService;
        public CoursController(ICoursService coursService)
        {
            _coursService = coursService;
        }
        // GET api/cours
        [EnableCors]
        public IQueryable<cours> Get()
        {
            //List<EF.EO.Category> categoryList = e.Categories.ToList();

            //string strJSON = JsonConvert.SerializeObject(categoryList,
            //new EFNavigationPropertyConverter());
            //return Content(strJSON, "application/json");
           
           // JsonConvert.SerializeObject();
            Logger.Instance.Info("logger test");
            return _coursService.GetCoursCategories().AsQueryable<cours>();
        }

        // GET api/cours/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/cours
        public void Post([FromBody]string value)
        {
        }

        // PUT api/cours/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/cours/5
        public void Delete(int id)
        {

        }
    }
}
