using System;
using System.Threading;
using System.Threading.Tasks;

namespace System.Java.Threading
{
    public class CountDownLatch: IDisposable
    {
        private readonly CancellationTokenSource token = new CancellationTokenSource();
        private static object o = new object();
        private int countDownNumber = 0;

        public CountDownLatch(int countDownNumber)
        {
            this.countDownNumber = countDownNumber;
        }

        public void CountDown()
        {
            lock (o)
            {
                if (this.countDownNumber > 0) this.countDownNumber--;
                if (countDownNumber == 0 && token.Token.CanBeCanceled) token.Cancel();
            }
        }

        public void Wait()
        {
            token.Token.WaitHandle.WaitOne();
        }

        public void Dispose()
        {
            token.Dispose();
        }

        public int GetCountDownNumber()
        {
            return this.countDownNumber;
        }
    }
}
