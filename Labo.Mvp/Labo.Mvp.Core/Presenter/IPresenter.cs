﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPresenter.cs" company="Labo">
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
//   Defines the IPresenter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Core.Presenter
{
    using Labo.Mvp.Core.Navigator;
    using Labo.Mvp.Core.View;

    /// <summary>
    /// The presenter interface.
    /// </summary>
    public interface IPresenter
    {
        /// <summary>
        /// Gets or sets the navigator.
        /// </summary>
        /// <value>
        /// The navigator.
        /// </value>
        INavigator Navigator { get; set; }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        object View { get; set; }

        /// <summary>
        /// Called when [load].
        /// </summary>
        void OnLoad();
    }

    /// <summary>
    /// The presenter interface.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TPresenter">The type of the presenter.</typeparam>
    public interface IPresenter<TView, TPresenter> : IPresenter 
        where TView : IView<TPresenter>
        where TPresenter : IPresenter<TView, TPresenter>
    {
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        new TView View { get; set; }
    }
}
