using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpAsyncFutures
{
    class Program
    {
        static void log(Object message)
        {
            Console.WriteLine("[" + Thread.CurrentThread.ManagedThreadId + "] " + message);
        }

        static void Main(string[] args)
        {
            log("Main enter");
            Client();
            log("Main leave");
            Console.ReadLine();
        }

        static async void Client()
        {
            log("Client enter");
            var future = Service(10);
            var x = await future;
            log("Client got future result " + x);
            Thread.Sleep(1000);
            log("Client future callback done.");
            log("Client leave");
        }

        static async Task<int> Service(int x)
        {
            log("Service enter");
            try
            {
                return await Task.Run(() => x * x);
            }
            finally
            {
                log("Service leave");
            }
        }
    }
}
