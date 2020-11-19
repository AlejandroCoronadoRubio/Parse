using System;
using System.Collections.Generic;

namespace Parse
{
    class Program
    {

        static string ParseSentence(string Sentence)
        {
            string[] SeparatedWords = null;

            string Result = string.Empty;

            char Separator = '\0';

            foreach (char Letter in Sentence)
            {
                if (!char.IsLetterOrDigit(Letter))
                {
                    SeparatedWords = Sentence.Split(Letter);
                    Separator = Letter;
                    break;
                }
            }

            if (Separator.Equals('\0'))
            {
                throw new ArgumentException("To parse the sentence It must contain some special character");
            }

            foreach (string Word in SeparatedWords)
            {
                char FirstLetter = Word[0];
                char LastLetter = Word[Word.Length-1];

                HashSet<char> WordHashSet = new HashSet<char>(Word.Substring(1, Word.Length - 2));

                Result += $"{FirstLetter}{WordHashSet.Count}{LastLetter}{Separator}";
            }

            return Result.Substring(0, Result.Length - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ParseSentence("Copyright,Microsoft,Corporation"));
            Console.WriteLine(ParseSentence("Copyright$Microsoft$Corporation"));
            Console.WriteLine(ParseSentence("Copyright Microsoft Corporation"));
            Console.WriteLine(ParseSentence("CopyrightMicrosoftCorporation")); //This one is going to throw an exception
        }
    }
}
