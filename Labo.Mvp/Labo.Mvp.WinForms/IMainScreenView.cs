// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMainScreenView.cs" company="Labo">
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
//   Defines the IMainScreenView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.WinForms
{
    using Labo.Mvp.Core.View;

    /// <summary>
    /// The main screen view interface.
    /// </summary>
    public interface IMainScreenView : IView<MainScreenPresenter>
    {
        /// <summary>
        /// Adds the user control.
        /// </summary>
        /// <param name="view">The view.</param>
        void AddUserControl(IView view);

        /// <summary>
        /// Adds the user control.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        void AddUserControl<TView>()
            where TView : IView;

        /// <summary>
        /// Adds the user control.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        void AddUserControl(string viewName);
    }
}