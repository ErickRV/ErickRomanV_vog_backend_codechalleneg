using System;
using System.Collections.Generic;

namespace VogCodeChallenge.Questions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //QuestionClass.Iterate();
            Console.WriteLine(TESTModule(4));
            Console.WriteLine(TESTModule(5));
            Console.WriteLine(TESTModule("someThing"));
            Console.WriteLine(TESTModule(1.0f));
            Console.WriteLine(TESTModule(false));
            try
            {
                Console.WriteLine(TESTModule(-1));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static object TESTModule(object val)
        {
            switch (Type.GetTypeCode(val.GetType())) {

                case TypeCode.Int32:
                    int intVal = (int)val;
                    if (intVal < 1)
                        throw new Exception("Integer values cannot be lower than 1!");

                    if(intVal <= 4)
                        return intVal * 2;
                    else
                        return intVal * 3;

                case TypeCode.Single:
                    float floatVal = (float)val;
                    if (floatVal == 1.0f || floatVal == 2.0f)
                        return 3.0f;
                    else return val;

                case TypeCode.String:
                    string stringVal = (string)val;
                    return stringVal.ToUpper();

                default:
                    return val;
            }
        }

    }
}
