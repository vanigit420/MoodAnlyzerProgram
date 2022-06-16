using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{

    public class MoodAnalyserFactory
    {
        public static object CreateObjectForMoodAnalyser(string className, string constructorName)
        {
            //create the pattern and checks whether constructor name and class name are equal
            string pattern = @"." + constructorName + "";
            Match result = Regex.Match(className, pattern);
            //if yes create the object
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                //if no class found then then throw class not found exception
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            //if constructor name not equal to class name then throw constructor not found exception
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
            }

        }
        public static object CreateObjectForMoodAnalyserParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = Type.GetType(className);
            try
            {
                //if yes create the object
                if (type.FullName.Equals(className) || type.Name.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                        object instance = info.Invoke(new object[] { message });
                        return instance;
                    }
                    //if no class found then then throw class not found exception
                    else
                    {
                        throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
                    }

                }
                //if constructor name not equal to class name then throw constructor not found exception
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public static string InvokeMoodAnalyser(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyser.MoodAnalyser");
                object moodAnalyseObject = MoodAnalyserFactory.CreateObjectForMoodAnalyserParameterizedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_METHOD_FOUND, "No method found");
            }
        }
        public static string SetFeild(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyze = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_EXCEPTION, "Message should not be null");
                }
                fieldInfo.SetValue(moodAnalyze, message);
                return moodAnalyze.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_FEILD_EXIST, "Field is not found");
            }
        }
    }
}