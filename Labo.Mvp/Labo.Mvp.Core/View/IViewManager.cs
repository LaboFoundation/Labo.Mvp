// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IViewManager.cs" company="Labo">
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
//   Defines the IViewManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Core.View
{
    /// <summary>
    /// The view manager interface.
    /// </summary>
    public interface IViewManager
    {
        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The view instance.</returns>
        IView GetView(string viewName, params object[] parameters);

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The view instance.</returns>
        TView GetView<TView>(params object[] parameters)
            where TView : IView;

        /// <summary>
        /// Registers the view.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="caption">The caption.</param>
        void RegisterView<TInterface, TImplementation>(string viewName, string caption)
            where TInterface : IView
            where TImplementation : TInterface;

        /// <summary>
        /// Gets the view definition.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <returns>The view definition.</returns>
        ViewDefinition GetViewDefinition(string viewName);

        /// <summary>
        /// Gets the view definition.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <returns>The view definition.</returns>
        ViewDefinition GetViewDefinition<TView>()
            where TView : IView;
    }
}
