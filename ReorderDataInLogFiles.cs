using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class ReorderDataInLogFiles
    {

        static void Main(string[] args)
        {
            string[] logs = new string[] { "dig1 0 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };
            ReorderLogFiles(logs);
        }

        public static string[] ReorderLogFiles(string[] logs)
        {
            List<string> letterLogs = new List<string>();
            List<string> digitLogs = new List<string>();

            foreach (string log in logs)
            {
                int contentStart = log.IndexOf(" ") + 1;

                if (Char.IsLetter (log[contentStart]))
                    letterLogs.Add(log);
                else
                    digitLogs.Add(log);
            }
            // var letterLogs = logs.Select(x => x.Split(' ')[1]).Where(x=>x.Any(char.IsDigit)).Select(x=>x).ToList();
            //for (int i = 0; i < logs.Length; i++)
            //{
            //    int c;
            //    bool res = int.TryParse(logs[i].Split(' ')[1], out c);
            //    if (res)
            //    {
            //        digitLogs.Add(logs[i]);
            //    }
            //    else
            //    {
            //        letterLogs.Add(logs[i]);
            //    }
            //}

            letterLogs.Sort((log1, log2) =>
                          {
                              // compare logs ignoring identifier
                             
                              int result = log1.Substring(log1.IndexOf(" ") + 1).CompareTo(log2.Substring(log2.IndexOf(" ") + 1));

                              
                              if (result == 0)
                              {
                                  string log1Identifier = log1.Substring(0, log1.IndexOf(" "));
                                  string log2Identifier = log2.Substring(0, log2.IndexOf(" "));
                                  result = log1Identifier.CompareTo(log2Identifier);
                              }

                              return result;
                          });

            letterLogs.AddRange(digitLogs);
            return letterLogs.ToArray();
        }
    }
}