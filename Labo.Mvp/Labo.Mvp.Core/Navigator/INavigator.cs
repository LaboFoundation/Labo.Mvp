// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INavigator.cs" company="Labo">
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
//   Defines the INavigator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Core.Navigator
{
    using Labo.Mvp.Core.View;

    /// <summary>
    /// The navigator interface.
    /// </summary>
    public interface INavigator
    {
        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="owner">The owner.</param>
        /// <param name="parameters">The parameters.</param>
        void OpenView<TView>(IView owner, params object[] parameters)
            where TView : IView;

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="parameters">The parameters.</param>
        void OpenView<TView>(params object[] parameters)
            where TView : IView;

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="parameters">The parameters.</param>
        void OpenView(string viewName, params object[] parameters);

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="message">The message.</param>
        void ShowMessage(string message);

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The view object.</returns>
        TView GetView<TView>(params object[] parameters) where TView : IView;

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The view object.</returns>
        IView GetView(string viewName, params object[] parameters);

        /// <summary>
        /// Closes the view.
        /// </summary>
        /// <param name="view">The view.</param>
        void CloseView(IView view);

        /// <summary>
        /// Refreshes the parent view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="parameters">The parameters.</param>
        void RefreshParentView(IView view, params object[] parameters);
    }
}
