﻿using System;
using BLAG.App.Helpers;
using BLAG.App.Services;
using BLAG.App.ViewModels;
using BLAG.App.Views;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;

namespace BLAG.App
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public AppBootstrapper()
        {
            Router = new RoutingState();

            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();
            Locator.CurrentMutable.RegisterConstant(new LoggingService {Level = LogLevel.Debug}, typeof(ILogger));

            using (var d = this.Log().Measure("IoC View setup"))
            {
                Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
                Locator.CurrentMutable.Register(() => new AnswerTextChoiceView(),
                    typeof(IViewFor<AnswerTextChoiceViewModel>));
                Locator.CurrentMutable.Register(() => new LeaderboardView(),
                    typeof(IViewFor<LeaderboardViewModel>));
                Locator.CurrentMutable.Register(() => new StartView(),
                    typeof(IViewFor<StartViewModel>));
                Locator.CurrentMutable.Register(() => new GameView(), 
                    typeof(IViewFor<GameViewModel>));
            }

            var startViewModel = new StartViewModel();
            Router
                .NavigateAndReset
                .Execute(startViewModel)
                .Subscribe();
        }

        public RoutingState Router { get; protected set; }

        public Page CreateMainPage()
        {
            // NB: This returns the opening page that the platform-specific
            // boilerplate code will look for. It will know to find us because
            // we've registered our AppBootstrappScreen.
            return new RoutedViewHost();
        }
    }
}