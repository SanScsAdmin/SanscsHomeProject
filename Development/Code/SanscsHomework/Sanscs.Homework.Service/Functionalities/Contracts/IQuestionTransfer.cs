using Sanscs.Homework.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanscs.Model;

namespace Sanscs.Service.Functionalities.Contracts
{
    public interface IQuestionTransfer
    {
        string GetQuestionContent(question input);
    }
}
