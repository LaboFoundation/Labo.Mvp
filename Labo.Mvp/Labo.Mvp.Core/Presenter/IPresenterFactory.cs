namespace Labo.Mvp.Core.Presenter
{
    using System;

    using Labo.Mvp.Core.View;

    /// <summary>
    /// The presenter factory interface.
    /// </summary>
    public interface IPresenterFactory
    {
        /// <summary>
        /// Creates the presenter.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TPresenter">The type of the presenter.</typeparam>
        /// <returns>The presenter instance.</returns>
        IPresenter<TView, TPresenter> CreatePresenter<TView, TPresenter>() 
            where TView : IView<TPresenter>
            where TPresenter : IPresenter<TView, TPresenter>;

        /// <summary>
        /// Registers the presenter.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TPresenter">The type of the presenter.</typeparam>
        void RegisterPresenter<TView, TPresenter>()
            where TView : IView<TPresenter>
            where TPresenter : IPresenter<TView, TPresenter>;

        /// <summary>
        /// Creates the presenter.
        /// </summary>
        /// <param name="viewType">Type of the view.</param>
        /// <param name="presenterType">Type of the presenter.</param>
        /// <returns>The presenter instance.</returns>
        IPresenter CreatePresenter(Type viewType, Type presenterType);
    }
}