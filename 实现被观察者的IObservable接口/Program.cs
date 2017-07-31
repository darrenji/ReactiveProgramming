using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using 代理和广播;

namespace 实现被观察者的IObservable接口
{
    class Program
    {
        static void Main(string[] args)
        {
            var market = new Market();
            var sub = market.Inspect("market inspected");

            //返回一个连接的被观察者序列
            market.Publish(123.4f);
        }
    }

    public class Market : IObservable<float>
    {
        //在多线程环境中，推荐使用ImmutableHashSet
        private List<IObserver<float>> observers = new List<IObserver<float>>();

        public IDisposable Subscribe(IObserver<float> observer)
        {
            observers.Add(observer);
            return Disposable.Create(() =>
            {
                observers.Remove(observer);
            });
        }

        public void Publish(float price)
        {
            foreach(var o in observers)
            {
                o.OnNext(price);
            }
        }
    }
}