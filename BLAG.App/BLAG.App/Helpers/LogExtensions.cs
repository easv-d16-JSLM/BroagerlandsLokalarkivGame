using System;
using System.Reactive.Disposables;
using Humanizer;
using Splat;

namespace BLAG.App.Helpers
{
    public static class LogExtensions
    {
        public static IDisposable Measure(this IFullLogger log, string message, Action<string> logLevel = null)
        {
            var start = DateTime.Now;
            return Disposable.Create(() =>
            {
                var elapsed = DateTime.Now - start;
                (logLevel ?? log.Info)(message + " took " + elapsed.Humanize());
            });
        }
    }
}