using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyserException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION, CLASS_NOT_FOUND, CONSTRUCTOR_NOT_FOUND
        }
        public MoodAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}