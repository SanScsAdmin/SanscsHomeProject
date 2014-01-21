using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanscs.Homework.Model.DTO
{
    public class ExamHistoryDTO
    {
        public int QuestionID { get; set; }
        public string Comment { get; set; }
        public bool IsCorrect { get; set; }
        public int TimeUsed { get; set; }
    }
}
