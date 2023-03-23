using System;

namespace Andrusenko_Lab2_WPF.Tools
{
    public class TooOldException : Exception
    {
        public TooOldException()
        {
        }
        public TooOldException(string message) : base(message)
        {
        }
    }
}
