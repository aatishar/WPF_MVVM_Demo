using Microsoft.Extensions.DependencyInjection;
using MVVMTools.Dialog;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MVVMTools
{
    public interface IMVVMApplication
    {
        IServiceCollection Container { get; }
        IDialogService DialogService { get; }
        INavigator Navigator { get; }
        IServiceProvider ServiceProvider { get; }
        IReadOnlyDictionary<string, (Type view, Type viewModel)> ViewViewModelPairs { get; }

        void Build();
        void RegisterDiaglog<TView, TViewModel>(string viewName)
            where TView : UserControl
            where TViewModel : BindableBase;
        void RegisterView<TView, TViewModel>()
            where TView : UserControl
            where TViewModel : BindableBase;
        void RegisterView<TView, TViewModel>(string viewName)
            where TView : UserControl
            where TViewModel : BindableBase;
    }
}