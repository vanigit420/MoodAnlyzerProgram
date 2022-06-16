using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    /// <summary>
    /// refactoring MoodAnalyser with parameterized constructure
    /// </summary>
    public class MoodAnalyser
    {
        public string message;
        public MoodAnalyser()
        {

        }
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            try
            {
                message = message.ToLower();
                if (message.Equals(string.Empty))
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EMPTY_EXCEPTION, "Mood should not be empty");

                }
                if (message.Equals(null))
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_EXCEPTION, "Mood should not be null");
                }
                if (message.Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "happy";
                }
            }
            catch (NullReferenceException e)
            {
                return "happy";
            }
        }
    }
}