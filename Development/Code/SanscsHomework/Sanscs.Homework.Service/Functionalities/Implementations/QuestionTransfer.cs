using Sanscs.Homework.Model.DTO;
using Sanscs.Service.Functionalities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanscs.Common.Helpers;
using System.IO;
using Sanscs.Model;
namespace Sanscs.Service.Functionalities.Implementations
{
    public class QuestionTransfer : IQuestionTransfer
    {

        public string GetQuestionContent(question question)
        {
            
            string xsltPath = Path.Combine( @"F:\myproject\git\SanscsHomeProject\Development\Code\SanscsHomework\Sanscs.Homework.Web\XML\XSLT", string.Concat(question.question_type.name,".xslt"));
            return XsltHelper.TransFromXML(question.Content, xsltPath);
        }
    }
}
