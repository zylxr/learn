using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.dp
{
    public class LCSDPClass
    {
        public int[,] LongestCommonSubsequence(string str1,string str2)
        {
            var n1 = str1.Length;
            var n2 = str2.Length;
            var dp = new int[n1+1,n2+1];
            var b = new int[n1+1, n2+1];
            for(var i=1;i<=n1;i++)
            {
                for(var j=1;j<=n2;j++)
                {
                    if (str1[i-1] == str2[j-1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                        b[i, j] = 0;//匹配
                    }else
                    {
                        if (dp[i - 1, j] > dp[i,j-1])
                        {
                            dp[i, j] = dp[i - 1, j];
                            b[i, j] = 1;//left
                        }else
                        {
                            dp[i, j] = dp[i, j - 1];
                            b[i, j] = 2;//down
                        }
                    }
                }
            }
            return b;
        }

        public void OutputLCS(string str1, int str1_length,int str2_length, int[,] b)
        {
            if (str1_length == 0 || str2_length == 0) return;
            if (b[str1_length, str2_length] == 0)
            {
                OutputLCS(str1, str1_length - 1, str2_length - 1, b);
                Console.WriteLine($"{str1[str1_length-1]}");
            }
            else if (b[str1_length, str2_length] == 1)
            {
                OutputLCS(str1, str1_length - 1, str2_length, b);
            }
            else
            {
                OutputLCS(str1,str1_length,str2_length-1, b);
            }
        }
    }
}
