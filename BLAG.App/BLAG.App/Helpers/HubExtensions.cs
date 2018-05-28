using System;
using System.Reactive;
using System.Reactive.Linq;
using Microsoft.AspNetCore.SignalR.Client;

namespace BLAG.App.Helpers
{
    public static class HubExtensions
    {
        public static IObservable<Unit> Observe(this HubConnection hub, string methodName)
        {
            return Observable.Create<Unit>(obs => hub.On(methodName, () => obs.OnNext(Unit.Default)));
        }

        public static IObservable<T1> Observe<T1>(this HubConnection hub, string methodName)
        {
            return Observable.Create<T1>(obs => hub.On<T1>(methodName, obs.OnNext));
        }

        public static IObservable<Tuple<T1, T2>> Observe<T1, T2>(this HubConnection hub, string methodName)
        {
            return Observable.Create<Tuple<T1, T2>>(obs =>
                hub.On<T1, T2>(methodName, (t1, t2) => obs.OnNext(Tuple.Create(t1, t2))));
        }

        public static IObservable<Tuple<T1, T2, T3>> Observe<T1, T2, T3>(this HubConnection hub, string methodName)
        {
            return Observable.Create<Tuple<T1, T2, T3>>(obs =>
                hub.On<T1, T2, T3>(methodName, (t1, t2, t3) => obs.OnNext(Tuple.Create(t1, t2, t3))));
        }
    }
}