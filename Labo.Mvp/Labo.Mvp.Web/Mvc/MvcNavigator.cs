// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MvcNavigator.cs" company="Labo">
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
//   The mvc navigator class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Web.Mvc
{
    using System.Web.Mvc;

    using Labo.Mvp.Core.Navigator;
    using Labo.Mvp.Core.View;

    using IView = Labo.Mvp.Core.View.IView;

    /// <summary>
    /// The mvc navigator class.
    /// </summary>
    public class MvcNavigator : INavigator
    {
        /// <summary>
        /// The url helper
        /// </summary>
        private readonly UrlHelper m_Url;

        /// <summary>
        /// The view manager
        /// </summary>
        private readonly IViewManager m_ViewManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="MvcNavigator"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="viewManager">The view manager.</param>
        public MvcNavigator(UrlHelper url, IViewManager viewManager)
        {
            m_Url = url;
            m_ViewManager = viewManager;
        }

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="parameters">The parameters.</param>
        public void OpenView<TView>(params object[] parameters) 
            where TView : IView
        {
        }

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="parameters">The parameters.</param>
        public void OpenView(string viewName, params object[] parameters)
        {
            m_Url.RequestContext.HttpContext.Response.Redirect(m_Url.Action("Index", viewName));
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void ShowMessage(string message)
        {
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The view object.</returns>
        public TView GetView<TView>(params object[] parameters) where TView : IView
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The view object.</returns>
        public IView GetView(string viewName, params object[] parameters)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Closes the view.
        /// </summary>
        /// <param name="view">The view.</param>
        public void CloseView(IView view)
        {
        }

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="owner">The owner.</param>
        /// <param name="parameters">The parameters.</param>
        public void OpenView<TView>(IView owner, params object[] parameters) where TView : IView
        {
        }

        /// <summary>
        /// Refreshes the parent view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="parameters">The parameters.</param>
        public void RefreshParentView(IView view, params object[] parameters)
        {
        }
    }
}
