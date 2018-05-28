using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using BLAG.App.Helpers;
using Microsoft.AspNetCore.SignalR.Client;
using Splat;

namespace BLAG.App.Services
{
    public class SignalRService : IEnableLogger, IDisposable
    {
        private readonly HubConnection _client;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private SignalRService(HubConnection client)
        {
            _client = client;
            //Create observable for specified method name, make it so it can be connected to, all subscribtions will share the same one.
            GameStarted = _client.Observe(nameof(GameStarted)).Publish();
            //Connect ot the observable, so it's initialized and starts firing events. Keep the subscription active unitl this class is disposed.
            GameStarted.Connect().DisposeWith(_disposable);
        }

        //Client method that server calls. Has to be defined beforehand, other parts of app can subscribe.
        public IConnectableObservable<Unit> GameStarted { get; }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        public static async Task<SignalRService> Initialize(string url)
        {
            var client = new HubConnectionBuilder().WithUrl(url).Build();
            var service = new SignalRService(client);
            await client.StartAsync();
            return service;
        }

        //Server method definition. Signature has to be kept in sync with server hub manually.
        public Task SomeServerMethod(string somestring, int someInt)
        {
            return _client.SendAsync(nameof(SomeServerMethod), somestring, someInt);
        }
    }
}