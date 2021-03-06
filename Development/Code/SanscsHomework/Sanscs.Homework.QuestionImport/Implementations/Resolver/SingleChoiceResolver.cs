﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Sanscs.Homework.QuestionImport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Sanscs.Homework.Common.Helpers;
    using Sanscs.Homework.Model.DTO;
    public class SingleChoiceResolver : QuestionResolverBase, IQuestionResolver<string, QuestionDTO>
    {

        public IValidator<string> Validator
        {
            get;
            set;
        }

        public QuestionDTO Resolve(string input)
        {
            QuestionDTO model=null;
            if (Validator.Validate(input).Result)
            {
                Dictionary<string, string> properties = GetProperties(input);
                Dictionary<string, string> content = GetContent(input);
                Dictionary<string, string> choices = GetChoices(input);

                 model = new QuestionDTO
                {
                    QuestionNumber = properties["questionnumber"],
                    Solution = properties["answer"],
                    Score = int.Parse(properties["score"]),
                    Difficulty = int.Parse(properties["difficulty"]),
                    ResourceURL = properties["difficulty"],
                    Tags = properties["tags"],
                    Type=properties["type"],
                    Content=content["content"],
                };
            }
           return model;
        }
    }
}

