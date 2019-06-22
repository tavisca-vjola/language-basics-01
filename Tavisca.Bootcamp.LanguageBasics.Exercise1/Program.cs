using System;

namespace basics_1
{
    class Program
    {
    

       // static void Main(string[] args)
       // {
         //   Test("1?*2=24", 2);
          //  Test("42*?7=1974", 4);
           // Test("42*?47=1974", -1);
            //Test("2*12?=247", -1);
            //Console.ReadKey(true);
           
       // }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
        public static bool isexactmultiple(int []numbers)
        {
            if (numbers[0] * numbers[1] == numbers[2])
                return true;
            else
                return false;
        }
        public static string reverse(string str)
        {

            char[] chars = str.ToCharArray();
            char[] result = new char[chars.Length];
            for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
            {
                result[i] = chars[j];
            }
            return new string(result);

        }
        public static string Convertnumberstoequation(int[] numbers)
        {
            string ans = "";
            for (int j = 0; j <= 2; j++)
            {
               // Console.WriteLine(numbers[j]);
                string s = "";
                while (numbers[j] != 0)
                {
                    s += (numbers[j] % 10);
                    //Console.WriteLine(s);
                    numbers[j] /= 10;

                }

                ans += reverse(s);

                if (j == 0)
                    ans += '*';
                else if (j == 1)
                    ans += '=';
            }

            return ans;
        }
        public static bool exactequation(string ans,string equation)
        {
            for(int i=0;i<equation.Length;i++)
            {
                if (equation[i] == '?')
                    continue;
                else if (equation[i] != ans[i])
                    return false;
            }
            return true;
        }
        public static int FindDigit(string equation)
        {
            int [] numbers = new int[3];
            int ind=0, k = 0;
            for (int i = 0; i < equation.Length; i++)
            {
                if(equation[i]=='*'||equation[i]=='=')
                {
                    k++;
                }
                else if(equation[i]=='?')
                {
                    ind = i;
                    numbers[k] = -1;
                }

                else
                {
                    if(numbers[k]!=-1)
                    numbers[k] = numbers[k] * 10 + (equation[i] - '0');
                }
            }
            //Console.WriteLine(numbers[0]);
            if(numbers[0]==-1)
            {
                numbers[0] = numbers[2] / numbers[1];
                if (!isexactmultiple(numbers))
                    return -1;
                else
                {
                    string ans = Convertnumberstoequation(numbers);
                    Console.WriteLine(ans);
                    Console.WriteLine(equation);
                    if (exactequation(ans, equation))
                        return ans[ind]-'0';
                    else
                        return -1;
                }

            }
            else if(numbers[1]==-1)
            {
                numbers[1] = numbers[2] / numbers[0];
                if (!isexactmultiple(numbers))
                    return -1;
                else
                {
                    string ans = Convertnumberstoequation(numbers);
                    if (exactequation(ans, equation))
                          return ans[ind]-'0';
                    else
                        return -1;
                }
            }
            else
            {
                numbers[2] = numbers[1]*numbers[0];
               
                  string ans = Convertnumberstoequation(numbers);
                if (exactequation(ans, equation))
                {
                    

                    return ans[ind]-'0';
                }
                else
                    return -1; 
            }
         
            throw new NotImplementedException();
        }
    }
}
