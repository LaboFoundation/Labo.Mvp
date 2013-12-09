// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseControllerView.cs" company="Labo">
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
//   The base controller view class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Web.Mvc
{
    using System.Web.Mvc;

    using Labo.Mvp.Core;
    using Labo.Mvp.Core.Presenter;
    using Labo.Mvp.Core.View;

    using IView = Labo.Mvp.Core.View.IView;

    /// <summary>
    /// The base controller view class.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TPresenter">The type of the presenter.</typeparam>
    public class BaseControllerView<TView, TPresenter> : Controller, IView<TPresenter> 
        where TView : class, IView<TPresenter>
        where TPresenter : class, IPresenter<TView, TPresenter>
    {
        /// <summary>
        /// The view manager
        /// </summary>
        private readonly IViewManager m_ViewManager;

        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>
        /// The presenter.
        /// </value>
        public TPresenter Presenter { get; set; }

        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>
        /// The presenter.
        /// </value>
        object IView.Presenter
        {
            get { return Presenter; }
            set { Presenter = value as TPresenter; }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>
        /// The caption.
        /// </value>
        public string Caption
        {
            get { return ViewBag.Title; }
            set { ViewBag.Title = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseControllerView{TView, TPresenter}"/> class.
        /// </summary>
        protected BaseControllerView()
            : this(MvpApplication.PresenterFactory, MvpApplication.ViewManager)
        {
        }

        /// <summary>
        /// Called when [load].
        /// </summary>
        public virtual void OnLoad()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseControllerView{TView, TPresenter}"/> class.
        /// </summary>
        /// <param name="presenterFactory">The presenter factory.</param>
        /// <param name="viewManager">The view manager.</param>
        protected BaseControllerView(IPresenterFactory presenterFactory, IViewManager viewManager)
        {
            m_ViewManager = viewManager;

            Presenter = (TPresenter)presenterFactory.CreatePresenter<TView, TPresenter>();
            Presenter.View = (TView)(this as IView<TPresenter>);
        }

        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Presenter.Navigator = new MvcNavigator(Url, m_ViewManager);
            Presenter.OnLoad();

            base.OnActionExecuting(filterContext);
        }
    }
}
