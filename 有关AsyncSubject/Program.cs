using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using 代理和广播;

namespace 有关AsyncSubject
{
    class Program
    {
        static void Main(string[] args)
        {
            //异步编程通常这么写
            //Task<int> t = Task<int>.Factory.StartNew(() => 25);
            //int value = t.Result;
            //会给到异步编程的最后一个值


            var sernsor = new AsyncSubject<double>();
            sernsor.Inspect("async");

            sernsor.OnNext(1.0);
            sernsor.OnNext(2.0);
            sernsor.OnCompleted();

        }
    }
}