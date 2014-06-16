// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseNavigator.cs" company="Labo">
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
//   Defines the BaseNavigator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Core.Navigator
{
    using System;

    using Labo.Mvp.Core.Presenter;
    using Labo.Mvp.Core.View;

    /// <summary>
    /// The base navigator class.
    /// </summary>
    public abstract class BaseNavigator : INavigator
    {
        /// <summary>
        /// The view manager
        /// </summary>
        private readonly IViewManager m_ViewManager;

        /// <summary>
        /// The view activator
        /// </summary>
        private readonly IViewActivator m_ViewActivator;

        /// <summary>
        /// The presenter factory
        /// </summary>
        private readonly IPresenterFactory m_PresenterFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNavigator"/> class.
        /// </summary>
        /// <param name="viewManager">The view manager.</param>
        /// <param name="viewActivator">The view activator.</param>
        /// <param name="presenterFactory">The presenter factory.</param>
        protected BaseNavigator(IViewManager viewManager, IViewActivator viewActivator, IPresenterFactory presenterFactory)
        {
            m_ViewManager = viewManager;
            m_ViewActivator = viewActivator;
            m_PresenterFactory = presenterFactory;
        }

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="parameters">The parameters.</param>
        public void OpenView<TView>(params object[] parameters)
            where TView : IView
        {
            OpenView<TView>(null, parameters);
        }

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="owner">The owner.</param>
        /// <param name="parameters">The parameters.</param>
        public void OpenView<TView>(IView owner, params object[] parameters)
            where TView : IView
        {
            TView view = GetView<TView>(parameters);
            ViewDefinition viewDefinition = m_ViewManager.GetViewDefinition<TView>();
            OpenView(view, viewDefinition, owner);
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The view object.</returns>
        public TView GetView<TView>(params object[] parameters) where TView : IView
        {
            TView view = m_ViewManager.GetView<TView>(parameters);

            ActivateView(view);

            return view;
        }

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="parameters">The parameters.</param>
        public void OpenView(string viewName, params object[] parameters)
        {
            IView view = GetView(viewName, parameters);
            ViewDefinition viewDefinition = m_ViewManager.GetViewDefinition(viewName);
            OpenView(view, viewDefinition, null);
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>View object.</returns>
        public IView GetView(string viewName, params object[] parameters)
        {
            IView view = m_ViewManager.GetView(viewName, parameters);

            ActivateView(view);

            return view;
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void ShowMessage(string message);

        /// <summary>
        /// Closes the view.
        /// </summary>
        /// <param name="view">The view.</param>
        public abstract void CloseView(IView view);

        /// <summary>
        /// Refreshes the parent view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="parameters">The parameters.</param>
        public abstract void RefreshParentView(IView view, params object[] parameters);

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="view">The view.</param>
        /// <param name="viewDefinition">The view definition.</param>
        /// <param name="owner">The owner.</param>
        protected abstract void OpenView<TView>(TView view, ViewDefinition viewDefinition, IView owner);

        /// <summary>
        /// Activates the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="view">The view.</param>
        private void ActivateView<TView>(TView view) where TView : IView
        {
            Type viewType = view.GetType();
            Type genericViewInterfaceType = viewType.GetInterface(typeof(IView<>).Name);
            Type[] interfaces = viewType.GetInterfaces();
            Type genericViewImplementationInterfaceType = null;
            for (int i = 0; i < interfaces.Length; i++)
            {
                Type @interface = interfaces[i];
                if (@interface != genericViewInterfaceType && genericViewInterfaceType.IsAssignableFrom(@interface))
                {
                    genericViewImplementationInterfaceType = @interface;
                    break;
                }
            }

#if net45
            Type genericTypeArgument = genericViewInterfaceType.GenericTypeArguments[0];
#else
            Type genericTypeArgument = genericViewInterfaceType.GetGenericArguments()[0];
#endif


            m_ViewActivator.ActivateView(m_PresenterFactory, this, view, genericViewImplementationInterfaceType, genericTypeArgument);
        }
    }
}