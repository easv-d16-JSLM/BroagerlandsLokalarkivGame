﻿using ReactiveUI;
using Splat;

namespace BLAG.App.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject, IRoutableViewModel, IEnableLogger
    {
        protected ViewModelBase(IScreen hostScreen = null)
        {
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }

        public IScreen HostScreen { get; protected set; }

        public string UrlPathSegment { get; protected set; }
    }
}