// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultPresenterFactory.cs" company="Labo">
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
//   Defines the DefaultPresenterFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Core.Presenter
{
    using System;

    using Labo.Common.Ioc;
    using Labo.Mvp.Core.View;

    /// <summary>
    /// The default presenter factory class.
    /// </summary>
    public sealed class DefaultPresenterFactory : IPresenterFactory
    {
        /// <summary>
        /// Creates the presenter.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TPresenter">The type of the presenter.</typeparam>
        /// <returns>The presenter instance.</returns>
        public IPresenter<TView, TPresenter> CreatePresenter<TView, TPresenter>() 
            where TView : IView<TPresenter>
            where TPresenter : IPresenter<TView, TPresenter>
        {
            return IocContainer.Current.GetInstance<IPresenter<TView, TPresenter>>();
        }

        /// <summary>
        /// Creates the presenter.
        /// </summary>
        /// <param name="viewType">Type of the view.</param>
        /// <param name="presenterType">Type of the presenter.</param>
        /// <returns>The presenter instance.</returns>
        public IPresenter CreatePresenter(Type viewType, Type presenterType)
        {
            Type genericPresenterType = typeof(IPresenter<,>).MakeGenericType(viewType, presenterType);
            return (IPresenter)IocContainer.Current.GetInstance(genericPresenterType);
        }

        /// <summary>
        /// Registers the presenter.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TPresenter">The type of the presenter.</typeparam>
        public void RegisterPresenter<TView, TPresenter>() 
            where TView : IView<TPresenter>
            where TPresenter : IPresenter<TView, TPresenter>
        {
            IocContainer.Current.RegisterInstance<IPresenter<TView, TPresenter>, TPresenter>();
        }
    }
}