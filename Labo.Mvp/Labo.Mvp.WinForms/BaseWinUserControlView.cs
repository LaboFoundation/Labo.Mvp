// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseWinUserControlView.cs" company="Labo">
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
//   Defines the BaseWinUserControlView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.WinForms
{
    using System.Windows.Forms;

    using Labo.Mvp.Core.Presenter;
    using Labo.Mvp.Core.View;

    /// <summary>
    /// The base win user control view.
    /// </summary>
    /// <typeparam name="TPresenter">The type of the presenter.</typeparam>
    /// <typeparam name="TView">The type of the view.</typeparam>
    public abstract class BaseWinUserControlView<TPresenter, TView> : UserControl, IView<TPresenter>
        where TView : class, IView<TPresenter>
        where TPresenter : class, IPresenter<TView, TPresenter>
    {
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
            get { return Text; }
            set { Text = value; }
        }

        /// <summary>
        /// Called when [load].
        /// </summary>
        public virtual void OnLoad()
        {
        }
    }
}