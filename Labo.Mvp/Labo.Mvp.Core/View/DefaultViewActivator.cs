// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultViewActivator.cs" company="Labo">
//   The MIT License (MIT)
//   
//   Copyright (c) 2013 Bora Akgun
//   
//   Permission is hereby granted, free of charge, to any person obtaining a copy of
//   this software and associated documentation files (the "Software"), to deal in
//   the Software without restriction, including without limitation the rights to
//   use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
//   the Software, and to permit persons to whom the Software is furnished to do so,
//   subject to the following conditions:
//   
//   The above copyright notice and this permission notice shall be included in all
//   copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
//   FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//   COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//   IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
//   CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   Defines the DefaultViewActivator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Core.View
{
    using System;

    using Labo.Mvp.Core.Navigator;
    using Labo.Mvp.Core.Presenter;

    /// <summary>
    /// The default view activator class.
    /// </summary>
    public sealed class DefaultViewActivator : IViewActivator
    {
        /// <summary>
        /// Activates the view.
        /// </summary>
        /// <typeparam name="TPresenter">The type of the presenter.</typeparam>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="presenterFactory">The presenter factory.</param>
        /// <param name="navigator">The navigator.</param>
        /// <param name="viewInstance">The view instance.</param>
        public void ActivateView<TPresenter, TView>(IPresenterFactory presenterFactory, INavigator navigator, IView<TPresenter> viewInstance)
            where TView : IView<TPresenter>
            where TPresenter : IPresenter<TView, TPresenter>
        {
            TPresenter presenter = (TPresenter)presenterFactory.CreatePresenter<TView, TPresenter>();
            presenter.View = (TView)viewInstance;
            presenter.Navigator = navigator;
            presenter.OnLoad();

            viewInstance.Presenter = presenter;
            viewInstance.OnLoad();
        }

        /// <summary>
        /// Activates the view.
        /// </summary>
        /// <param name="presenterFactory">The presenter factory.</param>
        /// <param name="navigator">The navigator.</param>
        /// <param name="viewInstance">The view instance.</param>
        /// <param name="viewInterfaceType">Type of the view interface.</param>
        /// <param name="presenterType">Type of the presenter.</param>
        public void ActivateView(IPresenterFactory presenterFactory, INavigator navigator, IView viewInstance, Type viewInterfaceType, Type presenterType)
        {
            IPresenter presenter = presenterFactory.CreatePresenter(viewInterfaceType, presenterType);
            presenter.View = viewInstance;
            presenter.Navigator = navigator;
            presenter.OnLoad();

            viewInstance.Presenter = presenter;
            viewInstance.OnLoad();
        }
    }
}
