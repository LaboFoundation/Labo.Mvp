// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewDefinition.cs" company="Labo">
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
//   Defines the ViewDefinition type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.Core.View
{
    using System;

    /// <summary>
    /// The view definition class.
    /// </summary>
    public sealed class ViewDefinition
    {
        /// <summary>
        /// Gets the view type.
        /// </summary>
        /// <value>
        /// The view type.
        /// </value>
        public Type ViewType { get; private set; }

        /// <summary>
        /// Gets the view caption.
        /// </summary>
        /// <value>
        /// The view caption.
        /// </value>
        public string Caption { get; private set; }

        /// <summary>
        /// Gets the type of the view open.
        /// </summary>
        /// <value>
        /// The type of the view open.
        /// </value>
        public ViewOpenType ViewOpenType { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewDefinition"/> class.
        /// </summary>
        /// <param name="viewType">The view type.</param>
        /// <param name="caption">The caption.</param>
        public ViewDefinition(Type viewType, string caption)
        {
            Caption = caption;
            ViewType = viewType;
            ViewOpenType = ViewOpenType.Modal;
        }
    }
}