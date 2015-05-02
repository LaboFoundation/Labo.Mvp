// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WinFormsNavigator.cs" company="Labo">
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
//   The windows forms navigator class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.WinForms
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using Labo.Common.Reflection;
    using Labo.Mvp.Core.Navigator;
    using Labo.Mvp.Core.Presenter;
    using Labo.Mvp.Core.View;

    /// <summary>
    /// The windows forms navigator class.
    /// </summary>
    public sealed class WinFormsNavigator : BaseNavigator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WinFormsNavigator"/> class.
        /// </summary>
        /// <param name="viewManager">The view manager.</param>
        /// <param name="viewActivator">The view activator.</param>
        /// <param name="presenterFactory">The presenter factory.</param>
        public WinFormsNavigator(IViewManager viewManager, IViewActivator viewActivator, IPresenterFactory presenterFactory)
            : base(viewManager, viewActivator, presenterFactory)
        {
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// Closes the view.
        /// </summary>
        /// <param name="view">The view.</param>
        public override void CloseView(IView view)
        {
            Form form = view as Form;
            
            if (form != null)
            {
                form.Close();
                form.Dispose();
            }
        }

        /// <summary>
        /// Refreshes the parent view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="parameters">The parameters.</param>
        public override void RefreshParentView(IView view, params object[] parameters)
        {
            Form form = view as Form;
            if (form != null)
            {
                Form owner = form.Owner;

                if (owner != null)
                {
                    IView ownerView = owner as IView;
                    
                    if (ownerView != null)
                    {
                        MethodInfo initViewMethodInfo = GetInitViewMethodInfo(owner);
                        ReflectionHelper.CallMethod(ownerView, initViewMethodInfo, parameters);

                        ownerView.OnLoad();
                    }
                }
            }
        }

        /// <summary>
        /// Opens the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="view">The view.</param>
        /// <param name="viewDefinition">The view definition.</param>
        /// <param name="owner">The owner.</param>
        protected override void OpenView<TView>(TView view, ViewDefinition viewDefinition, IView owner)
        {
            Form form = view as Form;
            form.StartPosition = FormStartPosition.CenterParent; //TODO Throw exception
            form.Owner = owner as Form;

            if (viewDefinition.ViewOpenType == ViewOpenType.Modal)
            {
                form.ShowDialog();
            }
            else
            {
                form.Show();
            }
        }

        /// <summary>
        /// Gets the initialize view method information.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <returns>The method info</returns>
        /// <exception cref="System.InvalidOperationException">
        /// </exception>
        private static MethodInfo GetInitViewMethodInfo(Form owner)
        {
            MethodInfo[] methods = owner.GetType()
                                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                        .Where(x => x.Name == "InitView")
                                        .ToArray();
            if (methods.Length == 0)
            {
                throw new InvalidOperationException();
            }

            if (methods.Length > 1)
            {
                throw new InvalidOperationException();
            }

            MethodInfo initViewMethodInfo = methods[0];
            return initViewMethodInfo;
        }
    }
}
