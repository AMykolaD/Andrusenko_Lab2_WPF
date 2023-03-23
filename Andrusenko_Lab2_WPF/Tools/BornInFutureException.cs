using System;

namespace Andrusenko_Lab2_WPF.Tools
{
    public class BornInFutureException:Exception
    {
        public BornInFutureException()
        {
        }
        public BornInFutureException(string message):base(message)
        {
        }
    }
}
