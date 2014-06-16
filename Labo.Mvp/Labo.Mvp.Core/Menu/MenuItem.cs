// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuItem.cs" company="Labo">
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
//   Defines the MenuItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Core.Menu
{
    using System;

    /// <summary>
    /// The menu item.
    /// </summary>
    [Serializable]
    public class MenuItem
    {
        /// <summary>
        /// The child items.
        /// </summary>
        private MenuItemCollection m_Children;

        /// <summary>
        /// The menu item parameters.
        /// </summary>
        private object[] m_Parameters;

        /// <summary>
        /// Gets the caption.
        /// </summary>
        /// <value>
        /// The caption.
        /// </value>
        public string Caption { get; private set; }

        /// <summary>
        /// Gets the name of the view.
        /// </summary>
        /// <value>
        /// The name of the view.
        /// </value>
        public string ViewName { get; private set; }

        /// <summary>
        /// Gets or sets the menu item parameters.
        /// </summary>
        /// <value>
        /// The menu item parameters.
        /// </value>
        public object[] Parameters
        {
            get { return m_Parameters ?? (m_Parameters = new object[0]); }
            set { m_Parameters = value; }
        }

        /// <summary>
        /// Gets or sets the child items.
        /// </summary>
        /// <value>
        /// The child items.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public MenuItemCollection Children
        {
            get { return m_Children ?? (m_Children = new MenuItemCollection()); }
            set { m_Children = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="parameters">The parameters.</param>
        public MenuItem(string caption, params object[] parameters)
            : this(caption, null, parameters)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="parameters">The parameters.</param>
        public MenuItem(string caption, string viewName, params object[] parameters)
        {
            Caption = caption;
            ViewName = viewName;
            Parameters = parameters;
        }
    }
}
