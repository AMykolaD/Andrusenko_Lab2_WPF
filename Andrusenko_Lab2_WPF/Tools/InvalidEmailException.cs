using System;

namespace Andrusenko_Lab2_WPF.Tools
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException()
        {
        }
        public InvalidEmailException(string message) : base(message)
        {
        }
    }
}
