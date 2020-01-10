using System;

namespace BLL
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base("Exception")
        {
            
        }
    }
}