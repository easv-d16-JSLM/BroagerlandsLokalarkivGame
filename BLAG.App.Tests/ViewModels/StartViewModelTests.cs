using System;
using BLAG.App.ViewModels;
using FluentAssertions;
using Microsoft.Reactive.Testing;
using ReactiveUI.Testing;
using Xunit;

namespace BLAG.App.Tests.ViewModels
{
    public class StartViewModelTests
    {
        [Theory]
        [InlineData("http://192.168.0.1/", "asdfg", "Asdfghjkl",true)]
        [InlineData("http://192.168.0.1/", "asdfgh", "Asdfghjkl", false)]
        [InlineData("wrong", "asdfg", "Asdfghjkl", false)]
        [InlineData("http://192.168.0.1/", "asdfg", "A", false)]
        [InlineData("http://192.168.0.1/", "asdfg", "asef456se", false)]
        public void Validation(string url,string code, string name, bool valid)
        {
            new TestScheduler().With(sched =>
            {
                var canExecute = default(bool?);
                var sv = new StartViewModel
                {
                    Url = url,
                    JoinCode = code,
                    Username = name
                };
                sv.Connect.CanExecute.Subscribe(b => canExecute = b);
                sched.Start();
                sched.AdvanceBy(1);
                canExecute.Should().Be(valid);
            });
        }
    }
}