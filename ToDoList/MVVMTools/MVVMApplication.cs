using Microsoft.Extensions.DependencyInjection;
using MVVMTools.Dialog;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MVVMTools
{
    public class MVVMApplication : IMVVMApplication
    {
        private IServiceCollection container;
        private IServiceProvider serviceProvider = default!;
        private IDictionary<string, (Type view, Type viewModel)> viewViewModelPairs;

        public IServiceProvider ServiceProvider
        {
            get => this.serviceProvider;
        }

        public IServiceCollection Container
        {
            get => this.container;
        }

        public INavigator Navigator
        {
            get => this.serviceProvider.GetRequiredService<INavigator>();
        }
        public IDialogService DialogService
        {
            get => this.serviceProvider.GetRequiredService<IDialogService>();
        }

        public IReadOnlyDictionary<string, (Type view, Type viewModel)> ViewViewModelPairs
        {
            get => (IReadOnlyDictionary<string, (Type view, Type viewModel)>)viewViewModelPairs;
        }

        public MVVMApplication()
        {
            container = new ServiceCollection();
            container.AddSingleton<IDialogService, DialogService>();
            container.AddSingleton<INavigator, Navigator>();
            container.AddSingleton<IMVVMApplication>(this);
            viewViewModelPairs = new Dictionary<string, (Type view, Type viewModel)>();

        }

        public void RegisterView<TView, TViewModel>()
            where TView : UserControl
            where TViewModel : BindableBase
        {
            container.AddTransient<TView>();
            container.AddSingleton<TViewModel>();
            viewViewModelPairs.Add(typeof(TView).Name, (view: typeof(TView), viewModel: typeof(TViewModel)));

        }

        public void RegisterView<TView, TViewModel>(string viewName)
           where TView : UserControl
           where TViewModel : BindableBase
        {
            container.AddTransient<TView>();
            container.AddSingleton<TViewModel>();
            viewViewModelPairs.Add(viewName, (view: typeof(TView), viewModel: typeof(TViewModel)));

        }

        public void RegisterDiaglog<TView, TViewModel>(string viewName)
           where TView : UserControl
           where TViewModel : BindableBase
        {
            RegisterView<TView, TViewModel>(viewName);
        }

        public void Build()
        {
            serviceProvider = container.BuildServiceProvider();
        }
    }
}
