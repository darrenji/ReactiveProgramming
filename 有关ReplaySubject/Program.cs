using System;
using System.Reactive.Subjects;

namespace 有关ReplaySubject
{
    class Program
    {
        static void Main(string[] args)
        {
            //把OnNext()方法放到Subscribe方法之前执行，会发生什么？
            //var market = new Subject<float>();
            //market.OnNext(123);
            //market.Subscribe(x => Console.WriteLine($"Got the price {x}"));
            //以上这段代码什么都不显示
            //所以，Subscribe方法一定要放在OnNext方法之前


            //ReplaySubject
            //var market = new ReplaySubject<float>();
            //market.OnNext(123);
            //market.Subscribe(x => Console.WriteLine($"Got the price {x}"));
            //以上会显示


            //ReplaySubject还有重载方法
            //var timeWindow = TimeSpan.FromMilliseconds(500);
            //var market = new ReplaySubject<float>(timeWindow);
            //意思是延迟500毫秒后开始执行，在500毫秒之内的OnNext方法执行是无效的

            //还有一个重载方法是可以限制接受OnNext方法的数量
            //也就是控制流中OnNext的数量
            var market = new ReplaySubject<float>(1);
            market.OnNext(123);
            market.OnNext(456);
            //以上只有第二个OnNext方法生效
        }
    }
}