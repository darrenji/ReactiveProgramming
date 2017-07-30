using System;
using System.ComponentModel;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;

namespace RxSamples
{
    //观察者
    //class Program : IObserver<float>
    class Program
    {
        public Program()
        {
            //Market实现IObservable的写法
            //var market = new Market();
            //market.Subscribe(this);

            //观察者实现IObserver的写法
            //Subject就是对象，一个被观察的对象，所以这个对象也提供了被观察者订阅的方法,其内部实现了IObservable接口
            //var market = new Subject<float>();
            //market.Subscribe(this);


            ////接下来神奇的事情：被观察者调用观察者的方法
            //market.OnNext(1.2f);
            //market.OnCompleted();

            //观察者不实现IObserver<T>的写法
            var market = new Subject<float>();
            market.Subscribe(
                f => Console.WriteLine($"price is {f}"),
                () => Console.WriteLine("sequence is completed")
            );
            market.OnNext(1.2f);
            market.OnCompleted();
        }

        static void Main(string[] args)
        {
            new Program();
        }

        //一下观察者实现IObserver<T>接口时需要
        //public void OnCompleted()
        //{
        //    Console.WriteLine("sequence is completed");
        //}

        //public void OnError(Exception error)
        //{
        //    Console.WriteLine($"we got an error {error.Message}");
        //}

        //public void OnNext(float value)
        //{
        //    Console.WriteLine($"market gave us {value}");
        //}
    }

    //被观察者，提供让观察者订阅的方法
    public class Market : IObservable<float>
    {
        public IDisposable Subscribe(IObserver<float> observer)
        {
            throw new NotImplementedException();
        }
    }

}