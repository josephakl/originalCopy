using System;
using System.Collections.Generic;
using System.Text;

namespace si2.tests.Exceptions
{
    public class InvalidLengthException : ArgumentOutOfRangeException
    {

        public InvalidLengthException()
            : base(String.Format("Program object code length must be less than 5 characters long"))
        {

        }


    }
}
