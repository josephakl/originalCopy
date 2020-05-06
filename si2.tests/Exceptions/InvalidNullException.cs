using si2.bll.Dtos.Results.Program;
using System;
using System.Collections.Generic;
using System.Text;

namespace si2.tests.Exceptions
{
   public class InvalidNullException : NullReferenceException    
    {

        public InvalidNullException()
            : base(String.Format("Program objects (code,name or type) cannot be null"))
        {

        }


    }
}
