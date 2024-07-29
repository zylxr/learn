using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Algorithm.DailyExcise
{
    public class AccountsMergeClass
    {
        //给定一个列表 accounts，每个元素 accounts[i] 是一个字符串列表，其中第一个元素 accounts[i][0] 是 名称(name)，其余元素是 emails 表示该账户的邮箱地址。
        //现在，我们想合并这些账户。如果两个账户都有一些共同的邮箱地址，则两个账户必定属于同一个人。
        //请注意，即使两个账户具有相同的名称，它们也可能属于不同的人，因为人们可能具有相同的名称。一个人最初可以拥有任意数量的账户，但其所有账户都具有相同的名称。
        //合并账户后，按以下格式返回账户：每个账户的第一个元素是名称，其余元素是 按字符 ASCII 顺序排列 的邮箱地址。账户本身可以以 任意顺序 返回。
        //示例 1：

        //输入：accounts = [["John", "johnsmith@mail.com", "john00@mail.com"], ["John", "johnnybravo@mail.com"], ["John", "johnsmith@mail.com", "john_newyork@mail.com"], ["Mary", "mary@mail.com"]]
        //输出：[["John", 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com'],  ["John", "johnnybravo@mail.com"], ["Mary", "mary@mail.com"]]
        //解释：
        //第一个和第三个 John 是同一个人，因为他们有共同的邮箱地址 "johnsmith@mail.com"。 
        //第二个 John 和 Mary 是不同的人，因为他们的邮箱地址没有被其他帐户使用。
        //可以以任何顺序返回这些列表，
        //例如答案[['Mary'，'mary@mail.com']，['John'，'johnnybravo@mail.com']，['John'，'john00@mail.com'，'john_newyork@mail.com'，'johnsmith@mail.com']] 也是正确的。
        //示例 2：

        //输入：accounts = [["Gabe", "Gabe0@m.co", "Gabe3@m.co", "Gabe1@m.co"],["Kevin", "Kevin3@m.co", "Kevin5@m.co", "Kevin0@m.co"],["Ethan", "Ethan5@m.co", "Ethan4@m.co", "Ethan0@m.co"],["Hanzo", "Hanzo3@m.co", "Hanzo1@m.co", "Hanzo0@m.co"],["Fern", "Fern5@m.co", "Fern1@m.co", "Fern0@m.co"]]
        //输出：[["Ethan", "Ethan0@m.co", "Ethan4@m.co", "Ethan5@m.co"],["Gabe", "Gabe0@m.co", "Gabe1@m.co", "Gabe3@m.co"],["Hanzo", "Hanzo0@m.co", "Hanzo1@m.co", "Hanzo3@m.co"],["Kevin", "Kevin0@m.co", "Kevin3@m.co", "Kevin5@m.co"],["Fern", "Fern0@m.co", "Fern1@m.co", "Fern5@m.co"]]


        //提示：

        //1 <= accounts.length <= 1000
        //2 <= accounts[i].length <= 10
        //1 <= accounts[i][j].length <= 30
        //accounts[i][0] 由英文字母组成
        //accounts[i][j] (for j > 0) 是有效的邮箱地址
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            CheckSort();
            var emailToIndex = new Dictionary<string,int>();
            var emailToName = new Dictionary<string,string>();
            var emailCount = 0;
            foreach (var account in accounts)
            {
                var name = account[0];
                var count = account.Count();
                for(var i=1;i<count; i++)
                {
                    var email = account[i];
                    if(!emailToIndex.ContainsKey(email))
                    {
                        emailToIndex.Add(email, emailCount++);
                        emailToName.Add(email, name);
                    }
                }
            }

            var uf = new UnionFind(emailCount);
            foreach(var account in accounts)
            {
                var firstMail = account[1];
                var firstIndex = emailToIndex[firstMail];
                var count = account.Count;
                for(var i=2;i<count; i++)
                {
                    var nextMail = account[i];
                    var nextIndex = emailToIndex[nextMail];
                    uf.Union(firstIndex, nextIndex);
                }
            }

            var indexToMails = new Dictionary<int, List<string>>();
            foreach (var email in emailToIndex.Keys)
            {
                var index = uf.Find(emailToIndex[email]);
                indexToMails.TryGetValue(index, out var account);
                if (account == null)
                {
                   indexToMails.Add(index, new List<string> { email });
                }
                else account.Add(email);
            }

            var merged = new List<IList<string> > ();
            foreach (var emails in indexToMails.Values)
            {
                //默认 Array.Sort 或者 Sort 方法，对于字符串，并不严格按照 ascii 码排序，例:john_newyork@mail.com 就排在 john00@mail.com 前面，期望是 john00@mail.com在前面
                emails.Sort((a, b) => CompareByASCII(a,b));
                var arr = emails.ToArray();
                Array.Sort(arr, (a, b) => String.CompareOrdinal(a,b)); //ascii 排序
                var name = emailToName[emails[0]];
                var account = new List<string> { name };
                account.AddRange(emails);
                merged.Add(account);
            }
            return merged;
        }

        public class UnionFind
        {
            int[] parent;
            public UnionFind(int n)
            {
                parent = new int[n];
                for (var i = 0; i < n; i++)
                    parent[i] = i;
            }

            public void Union(int index1, int index2)
            {
                parent[Find(index2)] = Find(index1);
            }

            public int Find(int index)
            {
                if (parent[index] != index)
                {
                    parent[index] = Find(parent[index]);
                }
                return parent[index];
            }
        }

        public int CompareByASCII(string a, string b)
        {
            var i = 0;
            var j = 0;
            for (; i < a.Length && j < b.Length;)
            {
                if (a[i] == b[j]) { i++;j++;continue; }
                if (a[i] > b[j]) return 1;
                else return -1;
            }
            if (i == a.Length) return 1;
            return -1;
        }
        public void CheckSort()
        {
            var s1 = "john_newyork@mail.com";
            var s2 = "john00@mail.com";
            var s1greaters2 = false;
            for(int i=0,j=0;i<s1.Length && j<s2.Length;)
            {
                if (s1[i] == s2[j]) { i++; j++; continue; }
                if (s1[i] > s2[j]) { s1greaters2 = true; break; }
                else {  s1greaters2 = false; break; }
            }
        }
    }
}
