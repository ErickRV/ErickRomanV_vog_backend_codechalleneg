using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VogCodeChallenge.Questions
{
    public static class QuestionClass
    {
        static List<string> NamesList = new List<string>()
        {
            "Jimmy",
            "Jeffrey",
            "John",
        };

        public static void Iterate() {
            if (NamesList.Count == 0)
                return;

            string element = NamesList.First();
            Console.WriteLine(element);

            NamesList.Remove(element);
            Iterate();
        }

        //Bad practice???
        //public static void IterateUsingGoTo() {
        //    int length = NamesList.Count;
        //    int counter = 0;

        //Repeat:
        //    string item = NamesList[counter];
        //    Console.WriteLine(item);

        //    counter++;
        //    if (counter < length)
        //        goto Repeat;
        //}

        //Boring!
        //public static void IterateUsingWhile()
        //{
        //    int lengt = NamesList.Count;
        //    int counter = 0;
        //    while (counter < lengt) {
        //        Console.WriteLine(NamesList[counter]);
        //        counter++;
        //    }
        //}
    }
}
