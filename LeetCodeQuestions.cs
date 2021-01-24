using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
namespace LeetCodePractice
{
    class LeetCodeQuestions
    {


        static void Main(string[] args)
        {





            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int[][] matrix = new int[][] 
         { 
            new int[] {0,1,1,1},
             new int[] {1,1,1,1},
             new int[] {0,1,1,1}
                        //new int[] {0,1,1,1},
                        //           new int[] {0,1,1,1}
         };

            string s = "(()())(())";
            // string s = "abbaca";
            LeetCodeQuestions1 obj = new LeetCodeQuestions1();


         //   string ans = obj.RemoveOuterParentheses(s);
         //   int swp = obj.MinAddToMakeValid(s);
            int y = obj.CountSquares(matrix);
            string[] words = new string[] { "cat", "bt", "hat", "tree" };
            string word = "atach";
            int hh = obj.CountCharacters(words, word);
            int res = obj.FindPairs(nums, 2);
            obj.ThirdMax(nums);
            obj.TwoSum(nums, 9);
            string s1 = "fds";
            string s2 = "0";
            int n;
            bool success = int.TryParse(s1, out  n);
            bool success2 = int.TryParse(s2, out  n);


        }

        static void hellooo(int x = 1, bool flag = true)
        {
            Console.WriteLine("{0}{1}", x, flag);
        }

        enum days
        {

            s1, s2, s3, s4, s5, s6, s7, s8
        }




        static void hello(out int x)
        {
            x = 6;
        }



    }

    class LeetCodeQuestions1
    {
        public string RemoveOuterParentheses(string S)
        {
            StringBuilder sb = new StringBuilder();
            int brackets = 1;

            for(int i=1;i<S.Length;i++)
            {
                if(brackets==0)
                {
                    brackets++;

                }

                else if(brackets==1)
                {
                    if(S[i]=='(')
                    {
                        brackets++;
                        sb.Append(S[i]);
                    }
                    else
                    {
                        brackets--;
                    }
                }

                else
                {
                    if(S[i]=='(')
                    {
                        brackets++;
                        sb.Append(S[i]);
                    }
                    else
                    {
                        brackets--;
                        sb.Append(S[i]);
                    }
                }
            }

            return sb.ToString();
        
        }
        public string RemoveOuterParentheses2(string S)
        {



            Stack<char> ss = new Stack<char>();
            StringBuilder sb = new StringBuilder();

            foreach (char c in S)
            {
                if (ss.Count == 0)
                {
                    ss.Push(c);
                }

                else if (ss.Count == 1)
                {
                    if (c == '(')
                    {
                        ss.Push(c);
                        sb.Append(c);

                    }
                    else
                    {
                        ss.Pop();
                    }
                }

                else
                {
                    if (c == '(')
                    {
                        ss.Push(c);
                        sb.Append(c);

                    }
                    else
                    {
                        sb.Append(c);
                        ss.Pop();

                    }

                }
            }


            return sb.ToString();
        }



        public string RemoveOuterParentheses22(string S)
        {
            StringBuilder sb = new StringBuilder();
            int openBracketCount = 0;
            int closeBracketcount = 1;

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                {
                    if (openBracketCount == 0)
                    {
                        openBracketCount++;
                    }
                    else
                    {
                        openBracketCount++;
                        sb.Append(S[i]);

                    }
                }
                else
                {
                    if (closeBracketcount == openBracketCount)
                    {
                        closeBracketcount = 1;
                        openBracketCount = 0;
                    }
                    else
                    {
                        closeBracketcount++;
                        sb.Append(S[i]);
                    }
                }
            }
            return sb.ToString();
            //int counter = 0;
            //for (int i = 0; i < S.Length; i++) {
            //    if (S[i] == '(')
            //    {
            //        counter++;
            //    }
            //    else{
            //        counter--;
            //    }
            //    if (i < S.Length - 1 && counter == 0)
            //    {
            //        return S.Substring(1, i-1) + RemoveOuterParentheses(S.Substring(i + 1));
            //    }
            //    else if (i == S.Length - 1)
            //    {
            //        return S.Substring(1, i-1);
            //    }
            //}

            //return "";
        }
        public int[] TwoSum(int[] nums, int target)
        {

            // brutforce algorithm



            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    for (int j = 1; j < nums.Length - 2; j++)
            //    {
            //        if (nums[i] + nums[j] == target)
            //        {
            //            return new int[] {i, j};
            //        }
            //    }
            //}
            ////




            // var dictionary = nums.Select((val, index) => new { val, index }).ToDictionary(x => x.index, x => x.val);


            //   var dictionary = nums.Select((val, index) => new { val, index }).ToDictionary){( x => x.val, x => x.index)});
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dictionary.ContainsKey(nums[i]))
                {
                    dictionary.Add(nums[i], i);
                }
            }


            int[] output = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                int secondnumber = target - nums[i];
                if (dictionary.ContainsKey(secondnumber) && i != dictionary[secondnumber])
                {
                    output[0] = i;
                    output[1] = dictionary[secondnumber];
                    return output;
                }
            }

            return null;
        }



        public int ThirdMax(int[] nums)
        {

            if (nums.Length == 0) return -1;
            if (nums.Length == 1) return nums[0];

            int firstMax = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (firstMax < nums[i])
                {
                    firstMax = nums[i];
                }

            }

            int secondMax = firstMax;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < firstMax)
                {
                    if (firstMax == secondMax)
                    {
                        secondMax = nums[i];
                        continue;
                    }
                    if (nums[i] > secondMax)
                    {
                        secondMax = nums[i];
                    }


                }

            }

            int thirdMax = secondMax;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < secondMax)
                {
                    if (thirdMax == secondMax)
                    {
                        thirdMax = nums[i];
                        continue;
                    }
                    if (nums[i] > thirdMax)
                    {
                        thirdMax = nums[i];
                    }
                }
            }

            if (firstMax != secondMax && secondMax != thirdMax)
            {
                return thirdMax;
            }

            else
            {
                return firstMax;
            }


        }

        public int FindPairs(int[] nums, int k)
        {
            int count = 0;

            if (k < 0) return 0;
            Dictionary<int, int> mydictionary = new Dictionary<int, int>();
            HashSet<int> hs = new HashSet<int>();


            for (int i = 0; i < nums.Length; i++)
            {

                if (mydictionary.ContainsKey(nums[i]))
                {
                    mydictionary[nums[i]] = 2;
                }
                else
                {
                    mydictionary.Add(nums[i], 1);
                }

            }

            for (int i = 0; i < mydictionary.Count; i++)
            {
                if (k == 0)
                {
                    if (mydictionary.ElementAt(i).Value == 2)
                    {
                        count++;
                    }
                }
                else
                {
                    int res = k + mydictionary.ElementAt(i).Key;
                    if (mydictionary.ContainsKey(res))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int CountCharacters(string[] words, string chars)
        {
            int count = 0;
            Dictionary<char, int> charsDictionary = new Dictionary<char, int>();


            for (int i = 0; i < chars.Length; i++)
            {
                if (charsDictionary.ContainsKey(chars[i]))
                {

                    charsDictionary[chars[i]]++;
                }
                else
                {
                    charsDictionary.Add(chars[i], 1);
                }
            }

            foreach (string word in words)
            {
                Dictionary<char, int> wordsDictionary = new Dictionary<char, int>();

                for (int i = 0; i < word.Length; i++)
                {
                    if (wordsDictionary.ContainsKey(word[i]))
                    {

                        wordsDictionary[word[i]]++;
                    }
                    else
                    {
                        wordsDictionary.Add(word[i], 1);
                    }
                }
                bool found = true;

                IEnumerator ie = wordsDictionary.GetEnumerator();
                while (ie.MoveNext())
                {

                    char key = ((KeyValuePair<char, int>)ie.Current).Key;
                    int val = ((KeyValuePair<char, int>)ie.Current).Value;

                    if (!charsDictionary.ContainsKey(key) || val > charsDictionary[key])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    count += word.Length;
                }
            }

            return count;

        }

        public int CountSquares(int[][] matrix)
        {


            int count = 0;
            bool marked = true;
            for (int k = 1; k <= matrix.Length && marked; k++)
            {
                marked = false;
                for (int i = 0; i < matrix.Length; i++)
                {


                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        if (matrix[i][j] == k)
                        {
                            marked = true;
                            count++;
                            if (i + 1 < matrix.Length && j + 1 < matrix[i].Length)
                            {
                                if (matrix[i][j + 1] == k && matrix[i + 1][j] == k && matrix[i + 1][j + 1] == k)
                                {
                                    matrix[i][j] = k + 1;
                                }
                            }

                        }
                    }
                }
            }



            return count;
        }


        public int MinAddToMakeValid(string S)
        {
            int count = 0;
            bool left = false;
            for (int i = 0; i < S.Length; i++)
            {

                if (S[i] == '(')
                {
                    left = true;
                    count++;



                }
                else if (S[i] == ')')
                {

                    if (left)
                    {
                        count--;
                        left = false;
                    }
                    else
                    {
                        count++;
                    }
                }
            }





            //for (int i = 0; i < S.Length; i++)
            //{
            //    if (S[i] == '(')
            //    {

            //        if (i < S.Length - 2)
            //        {
            //            if (S[i + 1] == ')')
            //            {
            //                i++;
            //                continue;
            //            }
            //            else
            //            {
            //                i++;
            //                count += 2;
            //            }
            //        }
            //        else
            //        {
            //            if (i == S.Length - 1)
            //            {
            //                count++;
            //            }
            //            else
            //            {
            //                if (S[i + 1] == ')')
            //                {
            //                    break;
            //                }
            //                else
            //                {
            //                    count++;
            //                    continue;
            //                }

            //            }

            //        }

            //    }

            //    if (S[i] == ')')
            //    {
            //        count++;
            //    }



            //}
            return count;
        }

        public string RemoveDuplicates(string S)
        {


            Stack<char> myStack = new Stack<char>();


            StringBuilder sb = new StringBuilder();
            sb.Append(S[0]);
            sb.Remove(0, 1);
            int sb_count = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (myStack.Count == 0)
                {
                    myStack.Push(S[i]);
                }
                else
                {
                    if (myStack.Peek() == S[i])
                    {
                        myStack.Pop();
                    }
                    else
                    {
                        myStack.Push(S[i]);
                    }
                }


                //////////// without using stack
                if (sb.Length == 0)
                {
                    sb.Append(S[i]);
                    sb_count++;
                }
                else
                {
                    if (sb[sb_count - 1] == S[i])
                    {
                        sb.Remove(sb_count - 1, 1);
                        sb_count--;
                    }
                    else
                    {
                        sb.Append(S[i]);
                        sb_count++;
                    }
                }
            }


            return sb.ToString();
        }

    }

}

