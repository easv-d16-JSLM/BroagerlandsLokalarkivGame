using System.Linq;
using BLAG.App.ViewModels;
using DynamicData;
using FluentAssertions;
using Microsoft.Reactive.Testing;
using ReactiveUI.Testing;
using Xunit;

namespace BLAG.App.Tests.ViewModels
{
    public class AnswerTextChoiceViewModelTests
    {
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
                answerSource.AddRange(Enumerable.Repeat("a",10));
                scheduler.AdvanceBy(1);
                vm.Answers.Should().HaveCount(11);
            }
        }
    }
}