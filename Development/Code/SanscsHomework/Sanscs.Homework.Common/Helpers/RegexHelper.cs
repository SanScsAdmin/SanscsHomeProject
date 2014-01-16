using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanscs.Homework.Common.Helpers
{
    public class RegexPool
    {
      public  readonly static string Property = @"^\[\b(?<property>\w+)\b\]:(?<value>[^\[\]\{$]+)";
      public readonly static string Content = @"\r\n\{(?<content>\r\n.+\r\n)\}";
      public readonly static string Choices = @"(?<choice>^[A-Z]\.[^\.]+\s*$)";
      public readonly static string Split = @"(\r\n){3,}";
      public readonly static string Type = @"\[type\]:(?<type>\w+)";
    }
}
