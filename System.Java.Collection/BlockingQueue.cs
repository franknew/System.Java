using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace System.Java.Collection
{
    public class BlockingQueue<T>: IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>
    {
        private readonly CancellationTokenSource notFullToken = new CancellationTokenSource();
        private readonly CancellationTokenSource notEmpytToken = new CancellationTokenSource();
        private ConcurrentQueue<T> queue = new ConcurrentQueue<T>();

        public int Count => queue.Count;

        public bool IsSynchronized => true;

        public void CopyTo(T[] array, int index)
        {
            queue.CopyTo(array, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return queue.GetEnumerator();
        }

        public T[] ToArray()
        {
            return queue.ToArray();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return queue.GetEnumerator();
        }

        public void Enqueue(T item)
        {
            queue.Enqueue(item);
        }
    }
}
