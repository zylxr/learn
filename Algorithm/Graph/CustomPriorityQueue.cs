using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    public class CustomPriorityQueue<T,K> where K:IComparable<K>
    {
        private List<Tuple<T, K>> _items;

        public CustomPriorityQueue()
        {
            _items = new List<Tuple<T, K>>();
        }

        public void EnQueue(T item, K priority)
        {
            var count = _items.Count;
            _items.Add(new Tuple<T, K> ( item, priority ));
            HeapifyUp(count);
        }

        public Tuple<T,K> Dequeue()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Priority queue is empty");
            var root = _items[0];
            _items[0] = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count-1);
            HeapifyDown(0);
            return root;
        }

        public bool IsEmpty()
        {
            return _items.Count == 0;
        }

        public void UpdatePriority(T item,K newPriority)
        {
            var index = _items.FindIndex(_ => _.Item1.Equals(item));
            if (index == -1)
                throw new ArgumentException($"Item not found in priority queue");
            _items[index] = new Tuple<T, K>(item, newPriority);
            HeapifyUp(index);
            HeapifyDown(index);
        }
        private void HeapifyUp(int index)
        {
            while(index>0)
            {
                var parent = (index - 1) >> 1;
                if (_items[parent].Item2.CompareTo(_items[index].Item2)<0) break;
                var tmp = _items[parent];
                _items[parent] = _items[index];
                _items[index] = tmp;
                index = parent;
            }
        }
        private void HeapifyDown(int index)
        {
            var leftIndex = 2 * index + 1;
            var rightIndex = 2 * index + 2;
            var smallestIndex = index;
            if (leftIndex <_items.Count &&_items[leftIndex].Item2.CompareTo(_items[smallestIndex].Item2)<0)
                smallestIndex = leftIndex;
            if(rightIndex<_items.Count && _items[rightIndex].Item2.CompareTo(_items[smallestIndex].Item2)<0)
                smallestIndex = rightIndex;
            if(smallestIndex  != index)
            {
                var tmp = _items[index];
                _items[index] = _items[smallestIndex];
                _items[smallestIndex] = tmp;
                HeapifyDown(smallestIndex);
            }
        }

    }
}
