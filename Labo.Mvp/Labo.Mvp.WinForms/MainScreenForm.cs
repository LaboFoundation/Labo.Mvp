// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainScreenForm.cs" company="Labo">
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
//   The main screen form class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Labo.Mvp.WinForms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using Labo.Mvp.Core.Menu;
    using Labo.Mvp.Core.View;

    using MenuItem = Labo.Mvp.Core.Menu.MenuItem;

    /// <summary>
    /// The main screen form class.
    /// </summary>
    public partial class MainScreenForm : Form, IMainScreenView
    {
        /// <summary>
        /// The menu items
        /// </summary>
        private readonly MenuItemCollection m_MenuItems;

        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>
        /// The presenter.
        /// </value>
        public MainScreenPresenter Presenter { get; set; }

        /// <summary>
        /// Gets or sets the parent view.
        /// </summary>
        /// <value>
        /// The parent view.
        /// </value>
        public IView ParentView { get; set; }

        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>
        /// The presenter.
        /// </value>
        object IView.Presenter
        {
            get { return Presenter; }
            set { Presenter = value as MainScreenPresenter; }
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
        /// Initializes a new instance of the <see cref="MainScreenForm"/> class.
        /// </summary>
        /// <param name="menuItems">The menu items.</param>
        public MainScreenForm(MenuItemCollection menuItems)
        {
            m_MenuItems = menuItems;

            InitializeComponent();

            Width = 800;
            Height = 600;
        }

        /// <summary>
        /// Called when [load].
        /// </summary>
        public virtual void OnLoad()
        {
            InitMenu(m_MenuItems);
        }

        /// <summary>
        /// Adds the user control.
        /// </summary>
        /// <param name="view">The view.</param>
        public void AddUserControl(IView view)
        {
            AddToMainLayoutPanel(view);
        }

        /// <summary>
        /// Adds the user control.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        public void AddUserControl<TView>()
            where TView : IView
        {
            AddToMainLayoutPanel(Presenter.Navigator.GetView<TView>());
        }

        /// <summary>
        /// Adds the user control.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        public void AddUserControl(string viewName)
        {
            AddToMainLayoutPanel(Presenter.Navigator.GetView(viewName));
        }

        /// <summary>
        /// Initializes the menu.
        /// </summary>
        /// <param name="menuItems">The menu items.</param>
        private void InitMenu(MenuItemCollection menuItems)
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                MenuItem menuItem = menuItems[i];
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(menuItem.Caption);
                viewsMenu.Items.Add(toolStripMenuItem);

                for (int j = 0; j < menuItem.Children.Count; j++)
                {
                    MenuItem child = menuItem.Children[j];
                    toolStripMenuItem.DropDownItems.Add(new ToolStripButton(child.Caption, null, (sender, args) => Presenter.Navigator.OpenView(child.ViewName, child.Parameters))
                    {
                        AutoSize = true,
                        DisplayStyle = ToolStripItemDisplayStyle.Text,
                    });
                }

                toolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            }
        }

        /// <summary>
        /// Adds the automatic main layout panel.
        /// </summary>
        /// <param name="view">The view.</param>
        private void AddToMainLayoutPanel(IView view)
        {
            int controlID = mainLayoutPanel.Controls.Count;
            UserControl userControl = (UserControl)view;
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Width = userControl.Width + 5;
            flowLayoutPanel.Name = "mainLayoutChild{0}".FormatWith(controlID);
            Label caption = new Label
                {
                    Name = "mainLayoutChildLbl{0}".FormatWith(controlID), 
                    Dock = DockStyle.Top, 
                    Text = view.Caption, 
                    Width = userControl.Width
                };
            caption.Font = new Font(new FontFamily("Arial"), 11, FontStyle.Bold);

            flowLayoutPanel.Height = userControl.Height + caption.Height + 5;
            flowLayoutPanel.Controls.Add(caption);
            flowLayoutPanel.Controls.Add(userControl);
            mainLayoutPanel.Controls.Add(flowLayoutPanel);
        }
    }
}
