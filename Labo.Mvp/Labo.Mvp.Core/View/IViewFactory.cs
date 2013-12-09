// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IViewFactory.cs" company="Labo">
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
//   Defines the IViewFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Core.View
{
    using System;

    /// <summary>
    /// The view factory interface.
    /// </summary>
    public interface IViewFactory
    {
        /// <summary>
        /// Creates the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="arguments">The arguments.</param>
        /// <returns>The view instance.</returns>
        TView CreateView<TView>(params object[] arguments)
           where TView : class, IView;

        /// <summary>
        /// Registers the view.
        /// </summary>
        /// <typeparam name="TViewInterface">The type of the view interface.</typeparam>
        /// <typeparam name="TViewImplementation">The type of the view implementation.</typeparam>
        void RegisterView<TViewInterface, TViewImplementation>()
            where TViewInterface : IView
            where TViewImplementation : TViewInterface, IView;

        /// <summary>
        /// Creates the view.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>The view instance.</returns>
        IView CreateView(Type type, params object[] arguments);
    }
}