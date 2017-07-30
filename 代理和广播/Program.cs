using System;
using System.Reactive.Subjects;

namespace 代理和广播
{
    class Program
    {
        static void Main(string[] args)
        {
            //这里可以看出：Subject既可以是观察者，也可以是被观察者
            //被观察者
            var market = new Subject<float>();

            //market的观察者
            //后来调用Inspect扩展方法，意思是marketConsumer成了一个被观察者
            //所以，marketConsumer既是观察者也是被观察者
            //在这里信息的来源来自market,marketConsumer拿到market的信息之后又处理了一下，所以market在这里就好像是个代理，又把信息广播了出去
            var marketConsumer = new Subject<float>();

            //观察者订阅被观察者,使用扩展方法
            //marketConsumer.SubscribeTo(market);

            //被观察者主动出击订阅观察者(通常是观察者订阅被观察者
            market.Subscribe(marketConsumer);

            marketConsumer.Inspect("market consumer");

            market.OnNext(1,2);
            market.OnCompleted();

        }
    }

    
    public static class MyExtensionMethods
    {
        //写一个针对IObserver的扩展方法，让它可以订阅publisher
        public static IDisposable SubscribeTo<T>(this IObserver<T> observer, IObservable<T> observable)
        {
            return observable.Subscribe(observer);
        }

        //针对观察者的扩展方方法，让观察者可以处理多个参数
        public static IObserver<T> OnNext<T>(this IObserver<T> self, params T[] args)
        {
            foreach (var arg in args)
            {
                self.OnNext(arg);
            }
            return self;
        }



        //写一个被观察者的扩展方法
        public static IDisposable Inspect<T>(this IObservable<T> self, string name)
        {
            return self.Subscribe(
                    x => Console.WriteLine($"{name} has generated new value {x}"),
                    ex => Console.WriteLine($"{name} has generated exception of {ex.Message}"),
                    () => Console.WriteLine($"{name} has new value completed")
                );
        }

    }
}