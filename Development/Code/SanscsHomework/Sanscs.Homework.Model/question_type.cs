//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sanscs.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class question_type
    {
        public question_type()
        {
            this.questions = new HashSet<question>();
        }
    
        public int ID { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<question> questions { get; set; }
    }
}
