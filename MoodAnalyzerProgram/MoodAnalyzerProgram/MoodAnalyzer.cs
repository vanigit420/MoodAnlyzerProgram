using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        //method to Analyse mood 
        public string AnalyseMood()
        {
            message = message.ToLower();
            if (message.Contains("sad"))
            {
                return "sad";
            }
            else
            {
                return "happy";
            }
        }
    }
}