using Microsoft.Extensions.DependencyInjection;
using MVVMTools.Dialog;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MVVMTools
{
    public class Navigator : INavigator
    {
        private static ContentControl? mainView;
        public static string GetRegisterViewContainer(DependencyObject obj)
        {
            return (string)obj.GetValue(RegisterViewContainerProperty);
        }

        public static void SetRegisterViewContainer(DependencyObject obj, string value)
        {
            obj.SetValue(RegisterViewContainerProperty, value);
        }

        // Using a DependencyProperty as the backing store for RegisterView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegisterViewContainerProperty =
            DependencyProperty.RegisterAttached("RegisterViewContainer", typeof(string), typeof(Navigator), new PropertyMetadata(PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            mainView = d as ContentControl;
        }


        private IServiceProvider serviceProvider;
        private IMVVMApplication application;

        public Navigator(IServiceProvider serviceProvider, IMVVMApplication application)
        {
            this.serviceProvider = serviceProvider;
            this.application = application;

        }

        public void Navigate(string viewName, IDictionary<string, object>? parameters = null)
        {
            if (mainView is null)
            {
                return;
            }

            var viewViewModelPairValue = application.ViewViewModelPairs[viewName];
            var view = serviceProvider.GetRequiredService(viewViewModelPairValue.view);
            var viewModel = serviceProvider.GetRequiredService(viewViewModelPairValue.viewModel);

            if (viewModel is INavigationAware navigationViewModel)
            {
                navigationViewModel.OnNavigateTo(parameters ?? new Dictionary<string, object>());
            }

            (view as UserControl)!.DataContext = viewModel;

            if (mainView.Content is UserControl currentView)
            {
                if (currentView is INavigationAware currentNavigationViewModel)
                {
                    currentNavigationViewModel.OnNavigateFrom();
                }

            }
            mainView.Content = view;
        }
    }
}
