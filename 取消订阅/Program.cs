using System;
using System.Reactive.Subjects;

namespace 取消订阅
{
    class Program
    {
        static void Main(string[] args)
        {
            //被观察者
            var sensor = new Subject<float>();
            using (sensor.Subscribe(Console.WriteLine))
            {
                sensor.OnNext(1.2f);
            }

            //这里不会显示，因为使用Using语句后，订阅的已经被取消了
            sensor.OnNext(2.6f);
        }
    }
}