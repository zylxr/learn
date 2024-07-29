using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class KMPAlgorithm
    {
        //KMP算法（Knuth-Morris-Pratt Algorithm）是一种高效字符串搜索算法，用于在一个主字符串中查找一个特定的模式字符串。
        //其显著优点在于，当模式串与主串的一部分匹配后，发生不匹配时，它能避免模式串的字符重新从头开始比较，而是利用已经得到的匹配信息来决定模式串应该跳过多少个字符，
        //直接进入下一个可能的匹配位置继续比较。这得益于KMP算法预先计算出的“部分匹配表”（或称“前缀函数表”、“失配函数表”），该表记录了模式串中每个前缀与其最长相同真前缀的关系。


        //KMP算法详解
        //部分匹配表（Partial Match Table）的构建
        //部分匹配表是一个与模式串等长的整数数组next[]，其中next[i] 表示模式串前缀T[0..i - 1]中最长相同真前缀的长度。所谓“相同真前缀”，是指除了自身外，它也是模式串中另一个后缀的前缀。
        //例如，对于模式串T = "ABABX"，部分匹配表如下：

        //i T[i]    前缀 相同真前缀   next[i]
        //0	A	""	N/A	-1
        //1	B	"A"	N/A	0
        //2	A	"AB"	"A"	1
        //3	B	"ABA"	"AB"	2
        //4	X	"ABAB"	N/A	0
        //构建部分匹配表的过程如下：

        //初始化next[0] = -1，表示空串没有相同真前缀。
        //对于模式串中第i个字符（i > 0），比较字符T[i] 与T[next[i - 1]]。如果它们相等，则next[i] = next[i - 1] + 1，
        //表示相同真前缀长度加一；如果不等，则将next[i] 设置为next[next[i - 1]]（回退到更早的相同真前缀），并继续递归比较，直到找到相等的字符或者回退至next[-1]（此时next[i] = 0）。

        //字符串匹配过程
        //有了部分匹配表，我们就可以进行高效字符串匹配：

        //初始化两个指针i（主串）和j（模式串），均指向各自的起始位置。
        //当i未到达主串末尾且j未到达模式串末尾时，循环执行以下步骤：
        //如果主串当前字符S[i] 与模式串当前字符T[j]相等，则同时移动两个指针i++和j++，继续比较下一个字符。
        //如果不相等，根据next[j] 的值来决定如何移动模式串指针j。由于next[j] 表示T[0..j - 1]的相同真前缀长度，我们可以直接将j设为next[j]，跳过已知的不匹配部分。i保持不变，继续比较S[i] 和T[j]。
        //如果j到达模式串末尾，说明找到了一个匹配，返回当前i作为匹配起始位置；否则，继续循环直至i到达主串末尾，表示未找到匹配。

        public int[] BuildPartialMatchTable(string pattern)
        {
            int patternLength = pattern.Length;
            int[] next = new int[patternLength];

            next[0] = -1;
            int j = -1;
            for (int i = 1; i < patternLength; i++)
            {
                while (j >= 0 && pattern[i] != pattern[j + 1])
                {
                    j = next[j];
                }

                if (pattern[i] == pattern[j + 1])
                {
                    j++;
                }
                next[i] = j;
            }

            return next;
        }

        public int[] BuildNext(string pattern)
        {
            var n = pattern.Length;
            var next = new int[n];
            next[0] = -1;
            var k = -1;
            var j = 0;
            while(j<n-1)
            {
                if (k == -1 || pattern[j] == pattern[k])
                {
                    next[++j] = ++k;
                }else
                {
                    k = next[k];
                }
            }
            //for(var i=1;i<n;i++)
            //{

            //    if (pattern[i] == pattern[j])
            //    {
            //        next[i] = j;
            //        j++;
            //    }
            //    else if(j>0)
            //    {
            //        j = next[j];
            //        while (pattern[i] != pattern[j] && j>0)
            //            j= next[j];
            //    }
            //    else
            //    {
            //        next[i] = -1;
            //    }
            //}
            return next;
        }
        public int SearchEx(string source, string pattern)
        {
            var next = BuildNext(pattern);
            var sIndex = 0;
            var tIndex = 0;
            var sLength = source.Length;
            var tLength = pattern.Length;
            while(sIndex< sLength && tIndex< tLength)
            {
                if (tIndex == -1|| source[sIndex] == pattern[tIndex])
                {
                    sIndex++;
                    tIndex++;
                }
                else
                {
                    tIndex = next[tIndex];
                }
            }
            if (tIndex == tLength)
                return sIndex - tIndex;
            return -1;
        }

        public int Search(string source, string pattern)
        {
            int[] partialMatchTable = BuildPartialMatchTable(pattern);

            int sourceIndex = 0;
            int patternIndex = 0;
            int sourceLength = source.Length;
            int patternLength = pattern.Length;

            while (sourceIndex < sourceLength && patternIndex < patternLength)
            {
                if (source[sourceIndex] == pattern[patternIndex])
                {
                    sourceIndex++;
                    patternIndex++;
                }
                else if (patternIndex > 0)
                {
                    patternIndex = partialMatchTable[patternIndex - 1] + 1;
                }
                else
                {
                    sourceIndex++;
                }
            }

            if (patternIndex == patternLength)
            {
                return sourceIndex - patternLength; // 返回匹配起始位置
            }
            else
            {
                return -1; // 没有找到匹配
            }
        }
    }
}
