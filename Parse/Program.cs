using System;
using System.Collections.Generic;

namespace Parse
{
    public class Program
    {

        public static string ParseSentence(string Sentence)
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

        public static string ParseSentence2(string Sentence) //Another implementation but with worst performance
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
                IList<char> SentenceCharArray = new List<char>(Word);
                char FirstLetter = SentenceCharArray[0];
                char LastLetter = SentenceCharArray[Word.Length - 1];

                for (int i = 1; i < SentenceCharArray.Count-2 ; i++)
                {
                    for (int j = i+1; j < SentenceCharArray.Count-1; j++)
                    {
                        if (SentenceCharArray[i] == SentenceCharArray[j])
                        {
                            SentenceCharArray.RemoveAt(j);
                            j--;
                        }
                    }
                }
                Result += $"{FirstLetter}{SentenceCharArray.Count-2}{LastLetter}{Separator}";
            }

            return Result.Substring(0, Result.Length - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ParseSentence2("Copyright Microsoft Corporation"));
            Console.WriteLine(ParseSentence("Copyright,Microsoft,Corporation"));
            Console.WriteLine(ParseSentence("Copyright$Microsoft$Corporation"));
            Console.WriteLine(ParseSentence("Copyright(Microsoft(Corporation"));
            Console.WriteLine(ParseSentence("CopyrightMicrosoftCorporation")); //This one is going to throw an exception
        }
    }
}
