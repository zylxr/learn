using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RemoveSubfoldersClass
    {
        //1233. 删除子文件夹
        //你是一位系统管理员，手里有一份文件夹列表 folder，你的任务是要删除该列表中的所有 子文件夹，并以 任意顺序 返回剩下的文件夹。

        //如果文件夹 folder[i] 位于另一个文件夹 folder[j] 下，那么 folder[i] 就是 folder[j] 的 子文件夹 。folder[j] 的子文件夹必须以 folder[j] 开头，后跟一个 "/"。例如，"/a/b" 是 "/a" 的一个子文件夹，但 "/b" 不是 "/a/b/c" 的一个子文件夹。

        //文件夹的「路径」是由一个或多个按以下格式串联形成的字符串：'/' 后跟一个或者多个小写英文字母。

        //例如，"/leetcode" 和 "/leetcode/problems" 都是有效的路径，而空字符串和 "/" 不是。


        //示例 1：

        //输入：folder = ["/a", "/a/b", "/c/d", "/c/d/e", "/c/f"]
        //输出：["/a", "/c/d", "/c/f"]
        //解释："/a/b" 是 "/a" 的子文件夹，而 "/c/d/e" 是 "/c/d" 的子文件夹。
        //示例 2：

        //输入：folder = ["/a", "/a/b/c", "/a/b/d"]
        //输出：["/a"]
        //解释：文件夹 "/a/b/c" 和 "/a/b/d" 都会被删除，因为它们都是 "/a" 的子文件夹。
        //示例 3：

        //输入: folder = ["/a/b/c", "/a/b/ca", "/a/b/d"]
        //输出: ["/a/b/c", "/a/b/ca", "/a/b/d"]


        //提示：

        //1 <= folder.length <= 4 * 104
        //2 <= folder[i].length <= 100
        //folder[i] 只包含小写字母和 '/'
        //folder[i] 总是以字符 '/' 起始
        //folder 每个元素都是 唯一 的

        public IList<string> RemoveSubfolders(string[] folder)
        {
            Array.Sort(folder);
            var ans = new List<string>();
            ans.Add(folder[0]);
            for(var i=1;i<folder.Length; i++)
            {
                var pre = ans[ans.Count - 1].Length;
                if (!(pre < folder[i].Length && ans[ans.Count - 1].Equals(folder[i].Substring(0, pre)) && folder[i][pre]=='/'))
                    ans.Add(folder[i]);
            }
            return ans;
        }

        public IList<string> RemoveSubfolders2(string[] folder)
        {
            var root = new Tree1();
            for(var i=0;i<folder.Length; i++)
            {
                var path = Split(folder[i]);
                var cur = root;
                foreach(var name in path)
                {
                    cur.children.TryAdd(name, new Tree1());
                    cur = cur.children[name];
                }
                cur.reference = i;
            }
            var ans = new List<string>();
            DFS(folder, ans, root);
            return ans;
        }
       
        public IList<string> Split(string s)
        {
            var ret = new List<string>();
            var cur = new StringBuilder();
            foreach(var ch in s)
            {
                if (ch == '/')
                {
                    ret.Add(cur.ToString());
                    cur.Length = 0;
                }
                else cur.Append(ch);
            }
            ret.Add(cur.ToString());
            return ret;
        }
        public void DFS(string[] folder, IList<string> ans,Tree1 cur)
        {
            if(cur.reference != -1)
            {
                ans.Add(folder[cur.reference]);
                return;
            }
            foreach (var child in cur.children.Values) DFS(folder, ans, child);
        }
    }

    public class Tree1
    {
        public int reference;
        public IDictionary<string, Tree1> children;
        public Tree1()
        {
            reference = -1;
            children = new Dictionary<string, Tree1>();
        }
    }
}
