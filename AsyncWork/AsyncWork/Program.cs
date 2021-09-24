using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            
            var taskArray = new[]{
                Task.Run(()=>{ Thread.Sleep(1000); Console.WriteLine("Task1 threadId {0}",
                    Thread.CurrentThread.ManagedThreadId); }),
                Task.Run(()=>{ Thread.Sleep(3000); Console.WriteLine("Task2 threadId {0}",
                    Thread.CurrentThread.ManagedThreadId); }),
                Task.Run(()=>{ Thread.Sleep(1000); Console.WriteLine("Task3 threadId {0}",
                    Thread.CurrentThread.ManagedThreadId); }),
                Task.Run(()=>{ Thread.Sleep(500); Console.WriteLine("Task4 threadId {0}",
                    Thread.CurrentThread.ManagedThreadId); }),
                Task.Run(()=>{ Thread.Sleep(500); Console.WriteLine("Task5 threadId {0}",
                    Thread.CurrentThread.ManagedThreadId); })
            };
            Task.WaitAll(taskArray);
            time.Stop();
            Console.WriteLine("Time elapsed : " + time.Elapsed);
            
            FactorialAsync(20);
            FactorialAsync(5);
        }
        
        static long Factorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
            
        static async void FactorialAsync(int n)
        {
            long result = await Task.Run(()=>Factorial(n));
            Console.WriteLine($"Factorial result =  {result}");
        }
    }
}