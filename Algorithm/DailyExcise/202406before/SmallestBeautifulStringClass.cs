﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class SmallestBeautifulStringClass
    {
        //如果一个字符串满足以下条件，则称其为 美丽字符串 ：
        //它由英语小写字母表的前 k 个字母组成。
        //它不包含任何长度为 2 或更长的回文子字符串。
        //给你一个长度为 n 的美丽字符串 s 和一个正整数 k 。
        //请你找出并返回一个长度为 n 的美丽字符串，该字符串还满足：在字典序大于 s 的所有美丽字符串中字典序最小。如果不存在这样的字符串，则返回一个空字符串。
        //对于长度相同的两个字符串 a 和 b ，如果字符串 a 在与字符串 b 不同的第一个位置上的字符字典序更大，则字符串 a 的字典序大于字符串 b 。
        //例如，"abcd" 的字典序比 "abcc" 更大，因为在不同的第一个位置（第四个字符）上 d 的字典序大于 c 。

        //示例 1：
        //输入：s = "abcz", k = 26
        //输出："abda"
        //解释：字符串 "abda" 既是美丽字符串，又满足字典序大于 "abcz" 。
        //可以证明不存在字符串同时满足字典序大于 "abcz"、美丽字符串、字典序小于 "abda" 这三个条件。

        //示例 2：
        //输入：s = "dc", k = 4
        //输出：""
        //解释：可以证明，不存在既是美丽字符串，又字典序大于 "dc" 的字符串。

        //提示：

        //1 <= n == s.length <= 105
        //4 <= k <= 26
        //s 是一个美丽字符串
        public string SmallestBeautifulString(string s, int k)
        {
            for (var i = s.Length - 1; i >= 0; i--)
            {
                var blockSet = new HashSet<char>();
                for(var j=1;j<3;j++)
                {
                    if (i - j < 0) continue;
                    blockSet.Add(s[i - j]);
                }
                for(var j=1;j<4;j++)
                {
                    if (s[i]-'a'+j+1<=k && !blockSet.Contains((char)(s[i] + j)))
                    {
                        return Generate(s, i, j);
                    }
                }
            }
            return "";
        }

        public string Generate(string s, int idx, int offset)
        {
            var res = s.ToCharArray();
            res[idx] = (char)(res[idx] + offset);
            for (var i = idx + 1; i < s.Length; i++)
            {
                var blockedSet = new HashSet<char>();
                for(var j=1;j<3;j++)
                {
                    if (i - j < 0) continue;
                    blockedSet.Add(res[i - j]);
                }
                for(var j=0;j<3;j++)
                {
                    if(!blockedSet.Contains((char)('a'+j)))
                    {
                        res[i] = (char)('a' + j);
                        break;
                    }
                }
            }
            return new string(res);
        }
    }
}