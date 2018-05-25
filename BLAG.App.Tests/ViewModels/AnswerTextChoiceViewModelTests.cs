using System;
using System.Linq;
using System.Reactive.Linq;
using BLAG.App.ViewModels;
using DynamicData;
using FluentAssertions;
using Microsoft.Reactive.Testing;
using ReactiveUI;
using ReactiveUI.Testing;
using Xunit;

namespace BLAG.App.Tests.ViewModels
{
    public class AnswerTextChoiceViewModelTests
    {
        [Fact]
        public void AddsAnswersInTime()
        {
            var obs = Observable.Interval(TimeSpan.FromSeconds(2)).Select(i =>
                Enumerable.Repeat(
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus fermentum tincidunt urna, et laoreet odio tempus id. Pellentesque turpis nisi, fringilla quis libero ac, egestas placerat est. Phasellus sagittis ligula nec nulla convallis gravida. Etiam a quam at lorem commodo fermentum. Donec ipsum metus, interdum in libero at, viverra ultricies est.",
                    Convert.ToInt32(i))).ToObservableChangeSet();
            
            var scheduler = new TestScheduler();
            using (TestUtils.WithScheduler(scheduler))
            {
                var vm = new AnswerTextChoiceViewModel(obs);
                scheduler.Start();
                scheduler.AdvanceByMs(1000);
                vm.Answers.Should().HaveCount(0);
                vm.Activator.Activate();
                scheduler.AdvanceByMs(20000);
                vm.Answers.Should().HaveCount(1);
            }
        }

        [Fact]
        public void ShowsAnswers()
        {
            var answerSource = new SourceList<string>();
            answerSource.Add("test");
            var scheduler = new TestScheduler();
            using (TestUtils.WithScheduler(scheduler))
            {
                var vm = new AnswerTextChoiceViewModel(answerSource.Connect());
                scheduler.Start();
                scheduler.AdvanceBy(1);
                vm.Answers.Should().HaveCount(0);
                vm.Activator.Activate();
                scheduler.AdvanceBy(1);
                vm.Answers.Should().HaveCount(1);
                answerSource.AddRange(Enumerable.Repeat("a", 10));
                scheduler.AdvanceBy(1);
                vm.Answers.Should().HaveCount(11);
            }
        }
    }
}