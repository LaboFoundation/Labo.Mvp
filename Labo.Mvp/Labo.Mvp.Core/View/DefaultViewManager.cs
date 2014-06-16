// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultViewManager.cs" company="Labo">
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
//   Defines the DefaultViewManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Core.View
{
    using System;
    using System.Collections.Concurrent;

    /// <summary>
    /// The default view manager class.
    /// </summary>
    public sealed class DefaultViewManager : IViewManager
    {
        /// <summary>
        /// The view factory
        /// </summary>
        private readonly IViewFactory m_ViewFactory;

        /// <summary>
        /// The view definitions
        /// </summary>
        private readonly ConcurrentDictionary<string, ViewDefinition> m_ViewDefinitions = new ConcurrentDictionary<string, ViewDefinition>();

        /// <summary>
        /// The view types
        /// </summary>
        private readonly ConcurrentDictionary<Type, string> m_ViewTypes = new ConcurrentDictionary<Type, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultViewManager"/> class.
        /// </summary>
        /// <param name="viewFactory">The view factory.</param>
        public DefaultViewManager(IViewFactory viewFactory)
        {
            m_ViewFactory = viewFactory;
        }

        /// <summary>
        /// Registers the view.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="caption">The caption.</param>
        public void RegisterView<TInterface, TImplementation>(string viewName, string caption)
            where TInterface : IView
            where TImplementation : TInterface
        {
            lock (this)
            {
                Type type = typeof(TInterface);
                m_ViewDefinitions.TryAdd(viewName, new ViewDefinition(type, caption));
                m_ViewTypes.TryAdd(type, viewName);
                m_ViewFactory.RegisterView<TInterface, TImplementation>();
            }
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The view instance.</returns>
        public IView GetView(string viewName, params object[] parameters)
        {
            lock (this)
            {
                ViewDefinition definition;
                if (!m_ViewDefinitions.TryGetValue(viewName, out definition))
                {
                    throw new InvalidOperationException("View '{0}' couldn't be found".FormatWith(viewName));
                }

                IView view = m_ViewFactory.CreateView(definition.ViewType, parameters);
                view.Caption = definition.Caption;

                return view;
            }           
        }

        /// <summary>
        /// Gets the view definition.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <returns>The view definition.</returns>
        public ViewDefinition GetViewDefinition(string viewName)
        {
            lock (this)
            {
                ViewDefinition definition;
                if (!m_ViewDefinitions.TryGetValue(viewName, out definition))
                {
                    throw new InvalidOperationException("View '{0}' couldn't be found".FormatWith(viewName));
                }

                return definition;
            }      
        }

        /// <summary>
        /// Gets the view definition.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <returns>The view definition.</returns>
        public ViewDefinition GetViewDefinition<TView>()
             where TView : IView
        {
            lock (this)
            {
                string viewName;
                Type type = typeof(TView);
                if (!m_ViewTypes.TryGetValue(type, out viewName))
                {
                    throw new InvalidOperationException("View '{0}' couldn't be found".FormatWith(type));
                }

                return GetViewDefinition(viewName);
            }
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The view instance.</returns>
        public TView GetView<TView>(params object[] parameters) 
            where TView : IView
        {
            lock (this)
            {
                string viewName;
                Type type = typeof(TView);

                if (!m_ViewTypes.TryGetValue(type, out viewName))
                {
                    throw new InvalidOperationException("View '{0}' couldn't be found".FormatWith(type));                    
                }

                return (TView)GetView(viewName, parameters);
            }
        }
    }
}