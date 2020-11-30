using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class CarException : ArgumentException
    {
        public int Value { get; }
        public CarException(string message, int value)
            : base(message)
        {
            Value = value;
        }
    }
    class SpeedException : Exception
    {
        public int Value { get; }
        public SpeedException(string message)
            : base(message)
        {
     
        }
    }
}
