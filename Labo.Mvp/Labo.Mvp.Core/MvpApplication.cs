// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MvpApplication.cs" company="Labo">
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
//   Defines the MvpApplication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Core
{
    using Labo.Mvp.Core.Navigator;
    using Labo.Mvp.Core.Presenter;
    using Labo.Mvp.Core.View;

    /// <summary>
    /// The mvp application class.
    /// </summary>
    public static class MvpApplication
    {
        /// <summary>
        /// The presenter factory
        /// </summary>
        private static readonly IPresenterFactory s_PresenterFactory = new DefaultPresenterFactory();

        /// <summary>
        /// The view manager
        /// </summary>
        private static readonly IViewManager s_ViewManager = new DefaultViewManager(new DefaultViewFactory());

        /// <summary>
        /// The view activator
        /// </summary>
        private static readonly IViewActivator s_ViewActivator = new DefaultViewActivator();

        /// <summary>
        /// The navigator
        /// </summary>
        private static INavigator s_Navigator;

        /// <summary>
        /// Gets the presenter factory.
        /// </summary>
        /// <value>
        /// The presenter factory.
        /// </value>
        public static IPresenterFactory PresenterFactory
        {
            get { return s_PresenterFactory; }
        }

        /// <summary>
        /// Gets the view manager.
        /// </summary>
        /// <value>
        /// The view manager.
        /// </value>
        public static IViewManager ViewManager
        {
            get { return s_ViewManager; }
        }

        /// <summary>
        /// Gets the navigator.
        /// </summary>
        /// <value>
        /// The navigator.
        /// </value>
        public static INavigator Navigator
        {
            get { return s_Navigator; }
        }

        /// <summary>
        /// Gets the view activator.
        /// </summary>
        /// <value>
        /// The view activator.
        /// </value>
        public static IViewActivator ViewActivator
        {
            get { return s_ViewActivator; }
        }

        /// <summary>
        /// Sets the navigator.
        /// </summary>
        /// <param name="navigator">The navigator.</param>
        public static void SetNavigator(INavigator navigator)
        {
            s_Navigator = navigator;
        }
    }
}
