//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sanscs.Homework.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class difficulty
    {
        public difficulty()
        {
            this.questions = new HashSet<question>();
            this.students_experience = new HashSet<students_experience>();
            this.difficultyweights = new HashSet<difficultyweight>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<question> questions { get; set; }
        public virtual ICollection<students_experience> students_experience { get; set; }
        public virtual ICollection<difficultyweight> difficultyweights { get; set; }
    }
}
