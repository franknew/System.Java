using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace System.Java.Threading
{
    public class CycleBarrier
    {
        private readonly CancellationTokenSource token = new CancellationTokenSource();
        private static object o = new object();
        private int cycleNumber = 0;
        private int cycleNumber_store = 0;
        private bool isWaiting = false;

        CycleBarrier(int cycleNumber)
        {
            cycleNumber = cycleNumber_store = cycleNumber;
        }

        public void Wait()
        {
            lock (o)
            {
                if (cycleNumber > 0) cycleNumber--;
                if (cycleNumber == 0 && token.Token.CanBeCanceled)
                {
                    isWaiting = false;
                    token.Cancel();
                }
                else if (!isWaiting)
                {
                    isWaiting = true;
                    token.Token.WaitHandle.WaitOne();
                }
            }
        }

        public void Reset()
        {
            lock (o)
            {
                cycleNumber = cycleNumber_store;
            }
        }
    }
}
