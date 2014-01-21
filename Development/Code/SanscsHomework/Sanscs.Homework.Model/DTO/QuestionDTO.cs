using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanscs.Homework.Model.DTO
{
  public  class QuestionDTO
    {
        public int ID { get; set; }
        public string QuestionNumber { get; set; }
        [JsonIgnore]
        public string Content { get; set; }
        public string ContentResult { get; set; }
        public string Solution { get; set; }
        public string ResourceURL { get; set; }
        public int Score { get; set; }
        public string Tips { get; set; }
        public string Tags { get; set; }
        public int Difficulty { get; set; }
        public string Type { get; set; }
    }
}
