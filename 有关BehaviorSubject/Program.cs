using System;
using System.Reactive.Subjects;
using 代理和广播;

namespace 有关BehaviorSubject
{
    class Program
    {
        static void Main(string[] args)
        {
            var sensorReading = new BehaviorSubject<double>(-1.0);
            //到这一步的时候，就是默认值-1
            sensorReading.Inspect("sensor");

            sensorReading.OnNext(0.99);
            sensorReading.OnCompleted();
        }
    }
}