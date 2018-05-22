using System;
using System.Collections.Generic;
using System.Text;
using BLAG.App.ViewModels;
using BLAG.App.Views;
using BLAG.Common.Models;
using DynamicData;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;

namespace BLAG.App
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public RoutingState Router { get; protected set; }

        public AppBootstrapper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            Locator.CurrentMutable.Register(() => new AnswerTextChoiceView(),
                typeof(IViewFor<AnswerTextChoiceViewModel>));
            //Locator.CurrentMutable.Register(() => new UpcomingMoviesCellView(),
            //    typeof(IViewFor<UpcomingMoviesCellViewModel>));
            //Locator.CurrentMutable.Register(() => new MovieDetailView(), typeof(IViewFor<MovieDetailViewModel>));

            //Locator.CurrentMutable.Register(() => new Cache(), typeof(ICache<,>));
            //Locator.CurrentMutable.Register(() => new ApiService(), typeof(IApiService));


            this
                .Router
                .NavigateAndReset
                .Execute(new AnswerTextChoiceViewModel(new AnswerTextChoice(){CorrectChoice = "asd",TextChoices = new List<string>{"1","2"}}))
                .Subscribe();
        }

        public Page CreateMainPage()
        {
            // NB: This returns the opening page that the platform-specific
            // boilerplate code will look for. It will know to find us because
            // we've registered our AppBootstrappScreen.
            return new RoutedViewHost();
        }
    }
}
