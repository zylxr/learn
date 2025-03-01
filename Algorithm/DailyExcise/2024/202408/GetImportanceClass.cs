using Algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class GetImportanceClass
    {
        //员工的重要性
        //你有一个保存员工信息的数据结构，它包含了员工唯一的 id ，重要度和直系下属的 id 。

        //给定一个员工数组 employees，其中：

        //employees[i].id 是第 i 个员工的 ID。
        //employees[i].importance 是第 i 个员工的重要度。
        //employees[i].subordinates 是第 i 名员工的直接下属的 ID 列表。
        //给定一个整数 id 表示一个员工的 ID，返回这个员工和他所有下属的重要度的 总和。




        //示例 1：



        //输入：employees = [[1, 5, [2, 3]],[2, 3, []],[3, 3, []]], id = 1
        //输出：11
        //解释：
        //员工 1 自身的重要度是 5 ，他有两个直系下属 2 和 3 ，而且 2 和 3 的重要度均为 3 。因此员工 1 的总重要度是 5 + 3 + 3 = 11 。


        //示例 2：



        //输入：employees = [[1, 2, [5]],[5, -3, []]], id = 5
        //输出：-3
        //解释：员工 5 的重要度为 -3 并且没有直接下属。
        //因此，员工 5 的总重要度为 -3。


        //提示：

        //1 <= employees.length <= 2000
        //1 <= employees[i].id <= 2000
        //所有的 employees[i].id 互不相同。
        //-100 <= employees[i].importance <= 100
        //一名员工最多有一名直接领导，并可能有多名下属。
        //employees[i].subordinates 中的 ID 都有效。

        public Dictionary<int, Employee> dictionary = new Dictionary<int, Employee>();
        public int GetImportance(IList<Employee> employees, int id)
        {
            foreach(var employee in employees)
            {
                dictionary.Add(employee.Id, employee);
            }
            return DFS(id);
        }

        public int GetImportanceByBFS(IList<Employee> employees, int id)
        {
            foreach (var employee in employees)
            {
                dictionary.TryAdd(employee.Id, employee); //DFS 和 BFS 共用 Dictionary, 故如果其中一个执行了，则相应的 key 会存在
            }
            var total = 0;
            var queue = new Queue<int>();
            queue.Enqueue(id);
            while(queue.Count>0)
            {
                var curId = queue.Dequeue();
                var employee = dictionary[curId];
                total += employee.Importance;
                var subordinaries = employee.SubOrdinates;
                foreach(var subId in subordinaries)
                {
                    queue.Enqueue(subId);
                }
            }
            return DFS(id);
        }


        public int DFS(int id)
        {
            var employee = dictionary[id];
            var total = employee.Importance;
            var subordinates = employee.SubOrdinates;
            foreach(var subId in subordinates)
            {
                total += DFS(subId);
            }
            return total;
        }
    }

    public class  Employee
    {
        public int Id { get; set; }
        public int Importance { get; set; }

        public IList<int> SubOrdinates { get; set; }
    }
}
